using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class SubModuleDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid ModuleId { get; set; }

        public ModuleDto? Module { get; set; }

        public string? RouteUrl { get; set; }
    }
}
