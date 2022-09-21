using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.General
{
    [ApiController]
    [Route(RouteConfig.Management.General.STATUS_ROUTE)]
    public class StatusController : BaseController
    {
        public StatusController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Status
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Status model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var status = new Status();
            Fill(ref status, model);
            await _context.Status.AddAsync(status);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]Status model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var status = await _context.Status.FindAsync(id);

            if (status == null)
                return NotFound();

            Fill(ref status, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var status = await _context.Status.FindAsync(id);

            if (status == null)
                return NotFound();

            _context.Status.Remove(status);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref Status entity, Status model)
        {
            entity.Description = model.Description;
            entity.Entity = model.Entity;
            entity.Observation = model.Observation;
        }
    }
}
