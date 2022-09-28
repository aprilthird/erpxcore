using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Rooms
{
    [ApiController]
    [Route(RouteConfig.Management.Rooms.ROOMSTATUS_ROUTE)]
    public class RoomStatusController : BaseController
    {
        public RoomStatusController(ApplicationDbContext context)
                    : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = _context.RoomStatus
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .AsQueryable();


            var result = await query
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoomStatus model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rt = new RoomStatus();
            Fill(ref rt, model);
            await _context.RoomStatus.AddAsync(rt);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RoomStatus model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rt = await _context.RoomStatus.FindAsync(id);

            if (rt == null)
                return NotFound();

            Fill(ref rt, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rt = await _context.RoomStatus.FindAsync(id);

            if (rt == null)
                return NotFound();

            _context.RoomStatus.Remove(rt);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref RoomStatus entity, RoomStatus model)
        {
            entity.Description = model.Description;
        }
    }
}
