using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.Guests
{
    [ApiController]
    [Route(RouteConfig.Management.Guests.GUEST_ROUTE)]
    public class GuestController : BaseController
    {
        public GuestController(ApplicationDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid? type = null)
        {
            var query = _context.Guests
                .Include(x => x.Status)
                .Where(x => x.StatusId == Constants.Status.ENABLED_ID)
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .AsQueryable();


            var result = await query
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Guest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var guest = new Guest();
            Fill(ref guest, model);
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Guest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var guest = await _context.Guests.FindAsync(id);

            if (guest == null)
                return NotFound();

            Fill(ref guest, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var guest = await _context.Guests.FindAsync(id);

            if (guest == null)
                return NotFound();

            guest.StatusId = Constants.Status.DISABLED_ID;
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref Guest entity, Guest model)
        {
            entity.Email = model.Email;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.DocumentTypeId = model.DocumentTypeId;
            entity.Document = model.Document;
            entity.PhoneNumber = model.PhoneNumber;
            entity.BirthDate = model.BirthDate;
            entity.UbigeoId = model.UbigeoId;
            entity.StatusId = Constants.Status.ENABLED_ID;
        }
    }
}
