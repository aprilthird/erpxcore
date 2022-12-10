using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class CompanyDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public Guid StatusId { get; set; }

        public StatusDto? Status { get; set; }

        public ICollection<CompanyHeadquarterDto>? CompanyHeadquarters { get; set; }
    }
}
