using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using ERP.XCore.Hotel.Shared.Resources.Rack;
using Microsoft.AspNetCore.Http;
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

            if(room.RoomStatus.Description == "Ocupado")
            {
                var roomBooking = await _context.RoomBookings
                    .Include(x => x.Guest)
                    .Include(x => x.PaymentMethod)
                    .Include(x => x.Room)
                    .ThenInclude(x => x.RoomType)
                    .Where(x => x.RoomId == id)
                    .OrderBy(x => x.CreatedAt)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return Ok(roomBooking);
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
        public async Task<IActionResult> CheckIn([FromBody] RoomBooking model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var rb = new RoomBooking();
            rb.RoomId = model.RoomId;
            rb.Code = (await _context.RoomBookings.CountAsync() + 1).ToString();
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
            rb.PaymentMethodId = model.PaymentMethodId;
            rb.Amount = model.Amount;
            rb.VoucherNumber = model.VoucherNumber;

            await _context.RoomBookings.AddAsync(rb);
            await _context.SaveChangesAsync();

            var room = await _context.Rooms.FindAsync(model.RoomId);
            var busyStatus = await _context.RoomStatus.Where(x => x.Description == "Ocupado").FirstOrDefaultAsync();
            room.RoomStatusId = busyStatus.Id;
            await _context.SaveChangesAsync();

            return Ok();
        }

		[HttpPost("extension")]
        public async Task<IActionResult> Extension([FromBody] RoomBookingExtensionResource model)
		{
            if (!ModelState.IsValid)
                return BadRequest();

            var roomBooking = await _context.RoomBookings
                    .FirstOrDefaultAsync(x => x.Id == model.RoomBookingId);
            roomBooking.ExitTime = model.ExitTime;
            roomBooking.ExitTime = roomBooking.ExitTime.AddHours(model.Meridian == 0 ? model.Hour : model.Hour + 12);
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
