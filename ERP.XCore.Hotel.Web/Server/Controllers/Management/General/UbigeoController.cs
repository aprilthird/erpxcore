using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.General
{
    [ApiController]
    [Route(RouteConfig.Management.General.UBIGEO_ROUTE)]
    public class UbigeoController : BaseController
    {
        public UbigeoController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Ubigeos
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ubigeo model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ubigeo = new Ubigeo();
            Fill(ref ubigeo, model);
            await _context.Ubigeos.AddAsync(ubigeo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Ubigeo model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ubigeo = await _context.Ubigeos.FindAsync(id);

            if (ubigeo == null)
                return NotFound();

            Fill(ref ubigeo, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ubigeo = await _context.Ubigeos.FindAsync(id);

            if (ubigeo == null)
                return NotFound();

            _context.Ubigeos.Remove(ubigeo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref Ubigeo entity, Ubigeo model)
        {
            entity.Citizenship = model.Citizenship;
            entity.CountryCode = model.CountryCode;
            entity.CountryName = model.CountryName;
            entity.DepartmentCode = model.DepartmentCode;
            entity.DepartmentName = model.DepartmentName;
            entity.ProvinceCode = model.ProvinceCode;
            entity.ProvinceName = model.ProvinceName;
            entity.DistrictCode = model.DistrictCode;
            entity.DistrictName = model.DistrictName;
        }
    }
}
