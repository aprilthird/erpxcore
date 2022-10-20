using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Security
{
	[ApiController]
	[Route(RouteConfig.Management.Security.PERMISSION_ROUTE)]
	public class PermissionController : BaseController
	{
		public PermissionController(ApplicationDbContext context) : base(context)
		{
		}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Permissions
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new Permission
                {
                    Id = x.Id,
                    RoleId = x.RoleId,
                    SubModuleId = x.SubModuleId,
                    PermissionLevelId = x.PermissionLevelId,
                    SubModule = new SubModule
                    {
                        ModuleId = x.SubModule.ModuleId,
                        Description = x.SubModule.Description,
                    },
                    PermissionLevel = new PermissionLevel
                    {
                        Description = x.PermissionLevel.Description,
                    },
                    Role = new ApplicationRole
                    {
                        Name = x.Role.Name,
                    }
                }).AsNoTracking().ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Permission model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var exists = await _context.Permissions
                .AnyAsync(x => x.RoleId == model.RoleId && x.SubModuleId == model.SubModuleId);

            if (exists)
                return BadRequest();

            var status = new Permission();
            Fill(ref status, model);
            await _context.Permissions.AddAsync(status);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Permission model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var exists = await _context.Permissions
                .AnyAsync(x => x.RoleId == model.RoleId && x.SubModuleId == model.SubModuleId && x.Id != id);

            //if (exists)
            //    return BadRequest();

            var status = await _context.Permissions.FindAsync(id);

            if (status == null)
                return NotFound();

            Fill(ref status, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var status = await _context.Permissions.FindAsync(id);

            if (status == null)
                return NotFound();

            _context.Permissions.Remove(status);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref Permission entity, Permission model)
        {
            entity.PermissionLevelId = model.PermissionLevelId;
            entity.SubModuleId = model.SubModuleId;
            entity.RoleId = model.RoleId;
        }
    }
}
