using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Business
{
    [ApiController]
    [Route(RouteConfig.Management.Business.WORK_AREA_ROUTE)]
    public class WorkAreaController : BaseController
    {
        public WorkAreaController(ApplicationDbContext context)
            : base(context)
        {
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.WorkAreas
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkArea model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var workArea = new WorkArea();
            Fill(ref workArea, model);
            await _context.WorkAreas.AddAsync(workArea);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] WorkArea model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var workArea = await _context.WorkAreas.FindAsync(id);

            if (workArea == null)
                return NotFound();

            Fill(ref workArea, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var workArea = await _context.WorkAreas.FindAsync(id);

            if (workArea == null)
                return NotFound();

            _context.WorkAreas.Remove(workArea);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref WorkArea entity, WorkArea model)
        {
            entity.Description = model.Description;
        }
    }
}
