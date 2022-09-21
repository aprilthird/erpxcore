using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Rooms
{
    [ApiController]
    [Route(RouteConfig.Management.Rooms.ROOM_ROUTE)]
    public class RoomController : BaseController
    {
        public RoomController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid? tipo = null)
        {
            var query = _context.Rooms
                .Include(x => x.Status)
                .Include(x => x.RoomType)
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .AsQueryable();

            if (tipo.HasValue)
                query = query.Where(x => x.RoomTypeId == tipo.Value);

            var result = await query
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Room model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var room = new Room();
            Fill(ref room, model);
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Room model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
                return NotFound();

            Fill(ref room, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
                return NotFound();

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref Room entity, Room model)
        {
            entity.Description = model.Description;
            entity.RoomTypeId = model.RoomTypeId;
            entity.StatusId = model.StatusId;
        }
    }
}
