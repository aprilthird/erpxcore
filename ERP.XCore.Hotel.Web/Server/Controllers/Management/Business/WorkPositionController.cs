using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Business
{
    [ApiController]
    [Route(RouteConfig.Management.Business.WORK_POSITION_ROUTE)]
    public class WorkPositionController : BaseController
    {
        public WorkPositionController(ApplicationDbContext context)
            : base(context)
        {
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.WorkPositions
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkPosition model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var workPosition = new WorkPosition();
            Fill(ref workPosition, model);
            await _context.WorkPositions.AddAsync(workPosition);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] WorkPosition model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var workPosition = await _context.WorkPositions.FindAsync(id);

            if (workPosition == null)
                return NotFound();

            Fill(ref workPosition, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var workPosition = await _context.WorkPositions.FindAsync(id);

            if (workPosition == null)
                return NotFound();

            _context.WorkPositions.Remove(workPosition);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref WorkPosition entity, WorkPosition model)
        {
            entity.Description = model.Description;
        }
    }
}
