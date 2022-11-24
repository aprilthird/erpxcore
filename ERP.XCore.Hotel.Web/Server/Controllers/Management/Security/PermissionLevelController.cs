using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Security
{
    [ApiController]
    [Route(ApiRouteConfig.Management.Security.PERMISSIONLEVEL_ROUTE)]
    public class PermissionLevelController : BaseController
    {
        public PermissionLevelController(ApplicationDbContext context)
                    : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.PermissionLevels
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PermissionLevel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sm = new PermissionLevel();
            Fill(ref sm, model);
            await _context.PermissionLevels.AddAsync(sm);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PermissionLevel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sm = await _context.PermissionLevels.FindAsync(id);

            if (sm == null)
                return NotFound();

            Fill(ref sm, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sm = await _context.PermissionLevels.FindAsync(id);

            if (sm == null)
                return NotFound();

            _context.PermissionLevels.Remove(sm);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref PermissionLevel entity, PermissionLevel model)
        {
            entity.Description = model.Description;
        }
    }
}
