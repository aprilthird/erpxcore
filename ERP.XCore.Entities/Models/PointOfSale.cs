using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class PointOfSale : BaseEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string? TicketPrinter { get; set; }

        public Guid CompanyHeadquarterId { get; set; }

        public CompanyHeadquarter? CompanyHeadquarter { get; set; }

        public Guid StatusId { get; set; }

        public Status? Status { get; set; }
    }
}
