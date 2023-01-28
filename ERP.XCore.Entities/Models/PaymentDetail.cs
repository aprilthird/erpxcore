using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class PaymentDetail : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid PaymentId { get; set; }

        public Payment Payment { get; set; }

        public Guid CurrencyId { get; set; }

        public Currency Currency { get; set; }

        public Guid PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public Guid RegisterUserId { get; set; }

        public ApplicationUser RegisterUser { get; set; }

        public Guid CashRegisterId { get; set; }

        public CashRegister CashRegister { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double SubTotal { get; set; }

        public string? VoucherNumber { get; set; }

        public double? ChargedAmount { get; set; }
    }
}
