﻿using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Security
{

    [ApiController]
    [Route(RouteConfig.Management.Security.ROLE_ROUTE)]
    public class RoleController : BaseController
    {
        public RoleController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) : base(context, userManager, roleManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Roles
                .AsNoTracking().ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationRole model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var applicationRole = new ApplicationRole();
            Fill(ref applicationRole, model);
            await _roleManager.CreateAsync(applicationRole);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ApplicationRole model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var applicationRole = await _context.Roles.FindAsync(id);

            if (applicationRole == null)
                return NotFound();

            Fill(ref applicationRole, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var applicationRole = await _context.Roles.FindAsync(id);

            if (applicationRole == null)
                return NotFound();

            _context.Roles.Remove(applicationRole);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref ApplicationRole entity, ApplicationRole model)
        {
            entity.Name = model.Name;
        }
    }
}
