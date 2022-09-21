using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Business
{
    [ApiController]
    [Route(RouteConfig.Management.Business.COMPANY_HEADQUARTER_ROUTE)]
    public class CompanyHeadquarterController : BaseController
    {
        public CompanyHeadquarterController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.CompanyHeadquarters
                .Where(x => x.StatusId == Constants.Status.ENABLED_ID)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new CompanyHeadquarter
                {
                    Id = x.Id,
                    Description = x.Description,
                    Address = x.Address,
                    CompanyId = x.CompanyId,
                    StatusId = x.StatusId,
                    Company = new Company
                    {
                        Description = x.Company.Description,
                        Code = x.Company.Code,
                        Address = x.Company.Address,
                    },
                    Status = new Status
                    {
                        Description = x.Status.Description,
                        Entity = x.Status.Entity,
                    }
                })
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyHeadquarter model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var companyHeadquarter = new CompanyHeadquarter();
            Fill(ref companyHeadquarter, model);
            await _context.CompanyHeadquarters.AddAsync(companyHeadquarter);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CompanyHeadquarter model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var companyHeadquarter = await _context.CompanyHeadquarters.FindAsync(id);

            if (companyHeadquarter == null)
                return NotFound();

            Fill(ref companyHeadquarter, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var companyHeadquarter = await _context.CompanyHeadquarters.FindAsync(id);

            if (companyHeadquarter == null)
                return NotFound();

            companyHeadquarter.StatusId = Constants.Status.DISABLED_ID;
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref CompanyHeadquarter entity, CompanyHeadquarter model)
        {
            entity.Description = model.Description;
            entity.Address = model.Address;
            entity.CompanyId = model.CompanyId;
            entity.StatusId = Constants.Status.ENABLED_ID;
        }
    }
}
