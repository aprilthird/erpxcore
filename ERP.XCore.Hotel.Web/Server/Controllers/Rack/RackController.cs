using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using ERP.XCore.Hotel.Shared.Resources.Rack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Rack
{
    [ApiController]
    [Route(ApiRouteConfig.Rack.RACK_ROUTE)]
    public class RackController : BaseController
    {
        public RackController(ApplicationDbContext context) : base(context)
        {
        }

        [HttpGet("detalle/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var room = await _context.Rooms
                .Include(x => x.RoomStatus)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (room == null)
                return NotFound();

            if(room.RoomStatus.Description == "Ocupado" || room.RoomStatus.Description == "Con Deuda")
            {
                var roomCheckIn = await _context.RoomCheckIns
                    .Where(x => x.RoomId == id)
                    .OrderByDescending(x => x.CreatedAt)
                    .Select(x => new RoomCheckIn
                    {
                        Id = x.Id,
                        Guest = x.Guest,
                        Status = x.Status,
                        PaymentMethod = x.PaymentMethod,
                        Code = x.Code,
                        EntryTime = x.EntryTime,
                        ExitTime = x.ExitTime,
                        Nights = x.Nights,
                        Hours = x.Hours,
                        RelatedCheckInId = x.RelatedCheckInId,
                        Amount = x.Amount,
                        ChargedAmount = x.ChargedAmount,
                        VoucherNumber = x.VoucherNumber,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt,
                        RoomId = x.RoomId,
                        FeeId = x.FeeId,
                        StatusId = x.StatusId,
                        Fee = x.Fee != null ? new Fee
                        {
                            Amount = x.Fee.Amount,
                            FeeTypeId = x.Fee.FeeTypeId,
                            FeeType = new FeeType
                            {
                                Description = x.Fee.FeeType.Description,
                                Currency = new Currency
                                {
                                    Code = x.Fee.FeeType.Currency.Code,
                                    Description = x.Fee.FeeType.Currency.Description,
                                }
                            }
                        } : null,
                        Room = new Room
                        {
                            Description = x.Room.Description,
                            RoomType = x.Room.RoomType,
                        },
                        Companions = x.Companions.Select(c => new RoomCheckInCompanion
                        {
                            Guest= c.Guest,
                        }).ToList(),
                        Details = x.Details.Select(d => new RoomCheckInDetail
                        {
                            Date = d.Date,
                            IsExtraAdded = d.IsExtraAdded,
                            IsExtension = d.IsExtension,
                        }).ToList(),
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return Ok(roomCheckIn);
            } 
            else if (room.RoomStatus.Description == "En Limpieza")
            {
                var roomCleaning = await _context.RoomCleanings
                    .Include(x => x.Employee)
                    .Include(x => x.Room)
                    .ThenInclude(x => x.RoomType)
                    .Where(x => x.RoomId == id)
                    .OrderBy(x => x.CreatedAt)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return Ok(roomCleaning);
            } 
            else if (room.RoomStatus.Description == "Sucio")
            {
                return Ok();
            }
            else if (room.RoomStatus.Description == "Mantenimiento")
            {
                var roomMaintenance = await _context.RoomMaintenances
                    .Include(x => x.Employee)
                    .Include(x => x.Room)
                    .ThenInclude(x => x.RoomType)
                    .Where(x => x.RoomId == id)
                    .OrderBy(x => x.CreatedAt)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return Ok(roomMaintenance);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("checkin")]
        public async Task<IActionResult> CheckIn([FromBody] RoomCheckIn model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var rb = new RoomCheckIn();
            rb.RoomId = model.RoomId;
            rb.Code = (await _context.RoomCheckIns.CountAsync() + 1).ToString();
            rb.EntryTime = DateTime.UtcNow;
            rb.Nights = model.Nights;
            rb.ExitTime = model.ExitTime;
            rb.ExitTime = rb.ExitTime.AddHours(model.Meridian == 0 ? model.Hour : model.Hour + 12);
            if(model.GuestId == null)
			{
                var guest = await _context.Guests.FirstOrDefaultAsync(x => x.Document == model.NewGuest);
                rb.GuestId = guest.Id;
			}
            else
			{
                rb.GuestId = model.GuestId;
            }

            var paymentMethod = await _context.PaymentMethods
                .FirstOrDefaultAsync(x => x.Id == model.PaymentMethodId);

            rb.FeeId = model.FeeId;
            rb.PaymentMethodId = model.PaymentMethodId;
            rb.Amount = model.Amount;
            rb.VoucherNumber = model.VoucherNumber;

            if (paymentMethod.Description == "Pagar al Salir")
                rb.StatusId = Constants.Status.PENDING_ID;
            else
                rb.StatusId = Constants.Status.ENABLED_ID;

			var companions = model.SelectedCompanionIds.Select(x => new RoomCheckInCompanion
            {
                GuestId = x,
                RoomCheckIn = rb
            }).ToList();

            await _context.RoomCheckIns.AddAsync(rb);
            if(companions != null && companions.Any())
            {
                await _context.RoomCheckInCompanions.AddRangeAsync(companions);
            }
            await _context.SaveChangesAsync();

            var room = await _context.Rooms.FindAsync(model.RoomId);
            var busyStatus = await _context.RoomStatus.Where(x => x.Description == "Ocupado").FirstOrDefaultAsync();
            var inDebtStatus = await _context.RoomStatus.Where(x => x.Description == "Con Deuda").FirstOrDefaultAsync();
            room.RoomStatusId = paymentMethod.Description == "Pagar al Salir"
                ? inDebtStatus.Id : busyStatus.Id;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("cancelar/{id}")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var room = await _context.Rooms
                .Include(x => x.RoomStatus)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (room == null)
                return NotFound();

            if (room.RoomStatus.Description != "Ocupado")
                return BadRequest();

            var roomCheckIn = await _context.RoomCheckIns
                .Include(x => x.Guest)
                .Include(x => x.Companions)
                .Include(x => x.Status)
                .Include(x => x.PaymentMethod)
                .Include(x => x.Room)
                .ThenInclude(x => x.RoomType)
                .Where(x => x.RoomId == id)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();

            if (roomCheckIn == null)
                return BadRequest();

            if (roomCheckIn.StatusId != Constants.Status.PENDING_ID)
                return BadRequest();

            roomCheckIn.StatusId = Constants.Status.DISABLED_ID;            
            var availableStatus = await _context.RoomStatus.Where(x => x.Description == "Disponible").FirstOrDefaultAsync();
            room.RoomStatusId = availableStatus.Id;
            await _context.SaveChangesAsync();

            return Ok();
        }

		[HttpPost("extension")]
        public async Task<IActionResult> Extension([FromBody] RoomCheckInExtensionResource model)
		{
            if (!ModelState.IsValid)
                return BadRequest();

            var roomCheckIn = await _context.RoomCheckIns
                    .FirstOrDefaultAsync(x => x.Id == model.RoomCheckInId);
            roomCheckIn.ExitTime = model.ExitTime;
            roomCheckIn.ExitTime = roomCheckIn.ExitTime.AddHours(model.Meridian == 0 ? model.Hour : model.Hour + 12);
			roomCheckIn.Nights = (roomCheckIn.ExitTime.Date - roomCheckIn.EntryTime.Date).Days;
			await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("limpieza")]
        public async Task<IActionResult> Cleaning([FromBody] RoomCleaning model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rc = new RoomCleaning();
            rc.RoomId = model.RoomId;
            rc.EmployeeId = model.EmployeeId;
            rc.StartedAt = DateTime.UtcNow;

            await _context.RoomCleanings.AddAsync(rc);
            await _context.SaveChangesAsync();

            var room = await _context.Rooms.FindAsync(model.RoomId);
            var cleaningStatus = await _context.RoomStatus.Where(x => x.Description == "En Limpieza").FirstOrDefaultAsync();
            room.RoomStatusId = cleaningStatus.Id;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
