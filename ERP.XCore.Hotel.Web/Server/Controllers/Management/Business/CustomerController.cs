using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Business
{
    [ApiController]
    [Route(RouteConfig.Management.Business.CUSTOMER_ROUTE)]
    public class CustomerController : BaseController
    {
        public CustomerController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = _context.Customers
                .AsNoTracking()
                .AsQueryable();

            var result = await query
                .Include(x => x.PersonType)
                .Include(x => x.DocumentType)
                .Include(x => x.Ubigeo)
                .Include(x => x.Company)
                .Include(x => x.Status)
                .Where(x => x.StatusId == Constants.Status.ENABLED_ID)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var c = new Customer();
            Fill(ref c, model);
            await _context.Customers.AddAsync(c);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Customer model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var c = await _context.Customers.FindAsync(id);

            if (c == null)
                return NotFound();

            Fill(ref c, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var c = await _context.Customers.FindAsync(id);

            if (c == null)
                return NotFound();

            c.StatusId = Constants.Status.DISABLED_ID;
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref Customer entity, Customer model)
        {
            entity.Description = model.Description;
            entity.PersonTypeId = model.PersonTypeId;
            entity.DocumentTypeId = model.DocumentTypeId;
            entity.Document = model.Document;
            entity.Sex = model.Sex;
            entity.BirthDate = model.BirthDate;
            entity.Direction = model.Direction;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Email = model.Email;
            entity.Website = model.Website;
            entity.MaritalStatus = model.MaritalStatus;
            entity.RetentionAgent = model.RetentionAgent;
            entity.UbigeoId = model.UbigeoId;
            entity.CompanyId = model.CompanyId;
            entity.StatusId = Constants.Status.ENABLED_ID;
        }
    }
}
