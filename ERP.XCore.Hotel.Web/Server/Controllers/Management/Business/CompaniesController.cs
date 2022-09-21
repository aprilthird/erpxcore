using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Business
{
    [ApiController]
    [Route(RouteConfig.Management.Business.COMPANY_ROUTE)]
    public class CompaniesController : BaseController
    {
        public CompaniesController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Companies
                .Include(x => x.Status)
                .Where(x => x.StatusId == Constants.Status.ENABLED_ID)
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Company model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var company = new Company();
            Fill(ref company, model);
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Company model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var company = await _context.Companies.FindAsync(id);

            if (company == null)
                return NotFound();

            Fill(ref company, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
                return NotFound();

            company.StatusId = Constants.Status.DISABLED_ID;
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref Company entity, Company model)
        {
            entity.Code = model.Code;
            entity.Description = model.Description;
            entity.Address = model.Address;
            entity.StatusId = Constants.Status.ENABLED_ID;
        }
    }
}
