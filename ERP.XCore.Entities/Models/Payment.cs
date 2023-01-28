using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class Payment : BaseEntity
    {
        public Guid Id { get; set; }

        public ICollection<PaymentDetail> Details { get; set; }
    }
}
