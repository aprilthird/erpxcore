﻿using ERP.XCore.Data.Context;
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
        public async Task<IActionResult> Status()
        {
            var result = await _context.Status
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
    }
}
