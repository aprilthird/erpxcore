using ERP.XCore.Data.Context;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ERP.XCore.Hotel.Web.Server.Controllers.Payment
{
    [ApiController]
    [Route(ApiRouteConfig.Payment.PAYMENT_METHOD_ROUTE)]
    public class PaymentMethodController : BaseController
    {
        public PaymentMethodController(ApplicationDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(bool? inDebt = null)
        {
            var query = _context.PaymentMethods
                .AsNoTracking()
                .AsQueryable();

            if (inDebt.HasValue)
                query = query.Where(x => x.InDebt == inDebt.Value);

            var result = await query.ToListAsync();

            return Ok(result);
        }
    }
}
