using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Security
{
    [ApiController]
    [Route(RouteConfig.Management.Security.SUBMODULE_ROUTE)]
    public class SubModuleController : BaseController
    {
        public SubModuleController(ApplicationDbContext context)
                    : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.SubModules
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new SubModule
                {
                    Description = x.Description,
                    ModuleId = x.ModuleId,
                    Module = new Module
                    {
                        Description = x.Module.Description,
                    }
                }).AsNoTracking().ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubModule model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sm = new SubModule();
            Fill(ref sm, model);
            await _context.SubModules.AddAsync(sm);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SubModule model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sm = await _context.SubModules.FindAsync(id);

            if (sm == null)
                return NotFound();

            Fill(ref sm, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sm = await _context.SubModules.FindAsync(id);

            if (sm == null)
                return NotFound();

            _context.SubModules.Remove(sm);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref SubModule entity, SubModule model)
        {
            entity.Description = model.Description;
            entity.ModuleId = model.ModuleId;
        }
    }
}
