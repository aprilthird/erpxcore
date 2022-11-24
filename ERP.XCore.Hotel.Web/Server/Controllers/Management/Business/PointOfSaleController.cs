using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Business
{
    [ApiController]
    [Route(ApiRouteConfig.Management.Business.POINT_OF_SALE_ROUTE)]
    public class PointOfSaleController : BaseController
    {
        public PointOfSaleController(ApplicationDbContext context)
            : base(context)
        {
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.PointsOfSale
                .Where(x => x.StatusId == Constants.Status.ENABLED_ID)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new PointOfSale
                {
                    Id = x.Id,
                    Description = x.Description,
                    CompanyHeadquarterId = x.CompanyHeadquarterId,
                    StatusId = x.StatusId,
                    CompanyHeadquarter = new CompanyHeadquarter
                    {
                        Description = x.CompanyHeadquarter.Description,
                        Address = x.CompanyHeadquarter.Address,
                        Company = new Company
                        {
                            Description = x.CompanyHeadquarter.Company.Description,
                            Code = x.CompanyHeadquarter.Company.Code,
                            Address = x.CompanyHeadquarter.Company.Address,
                        },
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
        public async Task<IActionResult> Create([FromBody] PointOfSale model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var pointOfSale = new PointOfSale();
            Fill(ref pointOfSale, model);
            await _context.PointsOfSale.AddAsync(pointOfSale);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PointOfSale model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var pointOfSale = await _context.PointsOfSale.FindAsync(id);

            if (pointOfSale == null)
                return NotFound();

            Fill(ref pointOfSale, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pointOfSale = await _context.PointsOfSale.FindAsync(id);

            if (pointOfSale == null)
                return NotFound();

            pointOfSale.StatusId = Constants.Status.DISABLED_ID;
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref PointOfSale entity, PointOfSale model)
        {
            entity.Description = model.Description;
            entity.TicketPrinter = model.TicketPrinter;
            entity.CompanyHeadquarterId = model.CompanyHeadquarterId;
            entity.StatusId = Constants.Status.ENABLED_ID;
        }
    }
}
