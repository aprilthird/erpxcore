using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class PointOfSaleDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string? TicketPrinter { get; set; }

        public Guid CompanyHeadquarterId { get; set; }

        public CompanyHeadquarterDto? CompanyHeadquarter { get; set; }

        public Guid StatusId { get; set; }

        public StatusDto? Status { get; set; }
    }
}
