using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
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
            var query = _context.RoomBookings
                .Include(x => x.Guest)
                .Include(x => x.PaymentMethod)
                .Include(x => x.Room)
                .ThenInclude(x => x.RoomType)
                .Where(x => x.RoomId == id)
                .OrderBy(x => x.CreatedAt)
                .AsNoTracking()
                .AsQueryable();

            var result = await query
                .FirstOrDefaultAsync();

            return Ok(result);
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
            rb.GuestId = model.GuestId;
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
    }
}
