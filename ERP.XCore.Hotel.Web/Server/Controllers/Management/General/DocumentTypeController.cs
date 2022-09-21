using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Management.General
{
    [ApiController]
    [Route(RouteConfig.Management.General.DOCUMENT_TYPE_ROUTE)]
    public class DocumentTypeController : BaseController
    {
        public DocumentTypeController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.DocumentTypes
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DocumentType model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var documentType = new DocumentType();
            Fill(ref documentType, model);
            await _context.DocumentTypes.AddAsync(documentType);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DocumentType model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var documentType = await _context.DocumentTypes.FindAsync(id);

            if (documentType == null)
                return NotFound();

            Fill(ref documentType, model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var documentType = await _context.DocumentTypes.FindAsync(id);

            if (documentType == null)
                return NotFound();

            _context.DocumentTypes.Remove(documentType);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private void Fill(ref DocumentType entity, DocumentType model)
        {
            entity.Description = model.Description;
            entity.Abbreviation = model.Abbreviation;
        }
    }
}
