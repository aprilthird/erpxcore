using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Configuration
{
	[ApiController]
	[Route(ApiRouteConfig.Configuration.FEE_ROUTE)]
	public class FeesController : BaseController
	{
		public FeesController(ApplicationDbContext context) 
			: base(context)
		{
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(Guid? roomTypeId = null)
        {
            var query = _context.Fees
                .AsNoTracking()
                .AsQueryable();

            if (roomTypeId.HasValue)
                query = query.Where(x => x.RoomTypeId == roomTypeId.Value);

            var result = await query
				.Include(x => x.FeeType)
				.ThenInclude(x => x.Currency)
				.Include(x => x.RoomType)
                .Include(x => x.Status)
				.Where(x => x.StatusId == Constants.Status.ENABLED_ID)
				.OrderByDescending(x => x.CreatedAt)
				.ToListAsync();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Fee model)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var existingFee = await _context.Fees
				.FirstOrDefaultAsync(x => x.FeeTypeId == model.FeeTypeId && x.RoomTypeId == model.RoomTypeId);

			if (existingFee != null)
				return BadRequest();

			var fee = new Fee();
			Fill(ref fee, model);
			await _context.Fees.AddAsync(fee);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] Fee model)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var existingFee = await _context.Fees
				.FirstOrDefaultAsync(x => x.Id != id && x.FeeTypeId == model.FeeTypeId && x.RoomTypeId == model.RoomTypeId);

			if (existingFee != null)
				return BadRequest();

			var fee = await _context.Fees.FindAsync(id);

			if (fee == null)
				return NotFound();

			Fill(ref fee, model);
			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var fee = await _context.Fees.FindAsync(id);

			if (fee == null)
				return NotFound();

			fee.StatusId = Constants.Status.DISABLED_ID;
			await _context.SaveChangesAsync();
			return Ok();
		}

		private void Fill(ref Fee entity, Fee model)
		{
			entity.Amount = model.Amount;
			entity.RoomTypeId = model.RoomTypeId;
			entity.FeeTypeId = model.FeeTypeId;
			entity.StatusId = Constants.Status.ENABLED_ID;
		}
	}
}
