using ERP.XCore.Data.Context;
using ERP.XCore.Hotel.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.PaymentMethods
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }
    }
}
