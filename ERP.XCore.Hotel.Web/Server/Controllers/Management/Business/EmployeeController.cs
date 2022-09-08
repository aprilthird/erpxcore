using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Business
{
    [ApiController]
    [Route(RouteConfig.Management.Business.EMPLOYEE_ROUTE)]
    public class EmployeeController : BaseController
    {
        public EmployeeController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? filtro = null, Guid? empresa = null, Guid? area = null, Guid? cargo = null)
        {
            var query = _context.Employees
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(filtro))
                query = query.Where(x => x.FirstName.Contains(filtro) || x.LastName.Contains(filtro) || x.Document.Contains(filtro));

            if (empresa.HasValue)
                query = query.Where(x => x.CompanyId == empresa.Value);

            if (area.HasValue)
                query = query.Where(x => x.WorkAreaId == area.Value);

            if (cargo.HasValue)
                query = query.Where(x => x.WorkPositionId == cargo.Value);

            var result = await query
                .Include(x => x.WorkArea)
                .Include(x => x.Company)
                .Include(x => x.WorkPosition)
                .Include(x => x.DocumentType)
                .Include(x => x.Status)
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employee = new Employee();
            Fill(ref employee, model);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Employee model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            Fill(ref employee, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref Employee entity, Employee model)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.DocumentTypeId = model.DocumentTypeId;
            entity.Document = model.Document;
            entity.UbigeoId = model.UbigeoId;
            entity.CompanyId = model.CompanyId;
            entity.WorkAreaId = model.WorkAreaId;
            entity.WorkPositionId = model.WorkPositionId;
            entity.Address = model.Address;
            entity.StatusId = model.StatusId;
        }
    }
}
