using ERP.XCore.Core.Helpers;
using ERP.XCore.Data.Context;
using ERP.XCore.Hotel.Shared.Helpers;
using ERP.XCore.Hotel.Shared.Resources.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.XCore.Hotel.Web.Server.Controllers
{
    [ApiController]
    [Route(RouteConfig.Select.SELECT_ROUTE)]
    public class SelectController : BaseController
    {
        public SelectController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpGet("estados")]
        public async Task<IActionResult> Status(string entity = Constants.Status.DEFAULT_ENTITY)
        {
            var result = await _context.Status
                .Where(x => x.Entity == entity)
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("tipos-de-documento")]
        public async Task<IActionResult> DocumentTypes()
        {
            var result = await _context.DocumentTypes
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("modulos")]
        public async Task<IActionResult> Modules()
        {
            var result = await _context.Modules
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }


        [HttpGet("tipos-de-persona")]
        public async Task<IActionResult> PersonTypes()
        {
            var result = await _context.PersonTypes
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }



        [HttpGet("ubigeos")]
        public async Task<IActionResult> Ubigeos()
        {
            var result = await _context.Ubigeos
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = $"{x.DepartmentCode}-{x.ProvinceCode}-{x.DistrictCode}"
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("empresas")]
        public async Task<IActionResult> Companies()
        {
            var result = await _context.Companies
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("sedes")]
        public async Task<IActionResult> CompanyHeadquarters()
        {
            var result = await _context.CompanyHeadquarters
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }


        [HttpGet("areas")]
        public async Task<IActionResult> WorkAreas()
        {
            var result = await _context.WorkAreas
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("cargos")]
        public async Task<IActionResult> WorkPositions()
        {
            var result = await _context.WorkPositions
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("empleados")]
        public async Task<IActionResult> Employees()
        {
            var result = await _context.Employees
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = $"{x.LastName}, {x.FirstName}"
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("tipos-de-habitacion")]
        public async Task<IActionResult> RoomTypes()
        {
            var result = await _context.RoomTypes
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> Roles()
        {
            var result = await _context.Roles
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Name
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("submodulos")]
        public async Task<IActionResult> SubModules()
        {
            var result = await _context.SubModules
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }

        [HttpGet("niveles-de-permiso")]
        public async Task<IActionResult> PermissionLevels()
        {
            var result = await _context.PermissionLevels
                .Select(x => new SelectResource<Guid>()
                {
                    Value = x.Id,
                    Text = x.Description
                }).ToListAsync();

            return Ok(result);
        }
    }
}
