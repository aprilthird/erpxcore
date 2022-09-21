using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class CompanyHeadquarter : BaseEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public Guid CompanyId { get; set; }

        public Company? Company { get; set; }

        public Guid StatusId { get; set; }

        public Status? Status { get; set; }

        public ICollection<PointOfSale>? PointsOfSale { get; set; }
    }
}
