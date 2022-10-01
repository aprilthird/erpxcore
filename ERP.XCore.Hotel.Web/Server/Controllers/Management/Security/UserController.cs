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
        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
            : base(context, userManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Users
                .Select(x => new ApplicationUser()
                {
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Employee = new Employee
                    {
                        FirstName = x.Employee.FirstName,
                        LastName = x.Employee.LastName
                    }
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
            await _userManager.CreateAsync(applicationUser, "XCore.2022");
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ApplicationUser model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var applicationUser = await _context.Users.FindAsync(id);

            if (applicationUser == null)
                return NotFound();

            Fill(ref applicationUser, model);
            await _context.SaveChangesAsync();
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
            entity.StatusId = model.StatusId;
            entity.EmailConfirmed = true;
        }
    }
}
