using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers
{
    [ApiController]
    [Route(ApiRouteConfig.Security.SECURITY_ROUTE)]
    public class SecurityController : BaseController
    {
        public SecurityController(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        [HttpGet("permisos")]
        public async Task<IActionResult> GetPermissions()
        {
            try
            {
                var userId = Guid.Parse(_userManager.GetUserId(User));
                var roles = await _context.Roles
                    .Where(x => x.UserRoles.Any(ur => ur.UserId == userId))
                    .ToListAsync();

                var permissions = await _context.Permissions
                    .Include(x => x.PermissionLevel)
                    .Include(x => x.SubModule)
                    .ThenInclude(x => x.Module)
                    .ToListAsync();

                var filteredPermissions = permissions
                    .Where(x => roles.Any(r => r.Id == x.RoleId))
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
                            RouteUrl = x.SubModule.RouteUrl,    
                            Module = new Module
                            {
                                Description = x.SubModule.Module.Description
                            }
                        },

                        PermissionLevel = new PermissionLevel
                        {
                            Description = x.PermissionLevel.Description,
                        }
                    }).ToList();

                return Ok(filteredPermissions);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
