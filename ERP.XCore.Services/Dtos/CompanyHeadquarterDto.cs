using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class CompanyHeadquarterDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public Guid CompanyId { get; set; }

        public CompanyDto? Company { get; set; }

        public Guid StatusId { get; set; }

        public StatusDto? Status { get; set; }

        public ICollection<PointOfSaleDto>? PointsOfSale { get; set; }
    }
}
