using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Security
{
    [ApiController]
    [Route(RouteConfig.Management.Security.USER_ROUTE)]
    public class UserController : BaseController
    {
        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
            : base(context, userManager, roleManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Users
                .Select(x => new ApplicationUser()
                {
                    Id = x.Id,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    EmployeeId = x.EmployeeId,
                    Employee = new Employee
                    {
                        FirstName = x.Employee.FirstName,
                        LastName = x.Employee.LastName
                    },
                    RoleId = x.UserRoles.Select(r => r.RoleId).FirstOrDefault(),
                }).AsNoTracking().ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationUser model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var applicationUser = new ApplicationUser();
            Fill(ref applicationUser, model);
            await _userManager.CreateAsync(applicationUser, model.Password);
            var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
            await _userManager.AddToRoleAsync(applicationUser, role.Name);
            //await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ApplicationUser model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var applicationUser = await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (applicationUser == null)
                return NotFound();

            Fill(ref applicationUser, model);
            await _userManager.UpdateAsync(applicationUser);
            var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
            await _userManager.RemoveFromRolesAsync(applicationUser, applicationUser.UserRoles.Select(x => x.Role.Name));
            await _userManager.AddToRoleAsync(applicationUser, role.Name);
            //await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var applicationUser = await _context.Users.FindAsync(id);

            if (applicationUser == null)
                return NotFound();

            _context.Users.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref ApplicationUser entity, ApplicationUser model)
        {
            entity.EmployeeId = model.EmployeeId;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.UserName = model.Email;
            entity.RoleId = model.RoleId;
            entity.StatusId = Constants.Status.ENABLED_ID;
            entity.EmailConfirmed = true;
        }
    }
}
