using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class RoomBooking : BaseEntity
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public Guid RelatedBookingId { get; set; }

        public RoomBooking RelatedBooking { get; set; }

        public Guid RoomId { get; set; }

        public Room Room { get; set; }

        public Guid GuestId { get; set; }

        public Guest Guest { get; set; }

        public DateTime EntryTime { get; set; }

        public DateTime ExitTime { get; set; }

        public int Nights { get; set; }

        public int? Hours { get; set; }

        public Guid PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public double Amount { get; set; }

        public double ChargedAmount { get; set; }

        public string VoucherNumber { get; set; }

    }
}
