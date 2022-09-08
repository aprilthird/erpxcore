using ERP.XCore.Data.Context;
using ERP.XCore.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ERP.XCore.Hotel.Web.Server.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ApplicationDbContext _context;

        protected UserManager<ApplicationUser> _userManager;

        public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public BaseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
    }
}
