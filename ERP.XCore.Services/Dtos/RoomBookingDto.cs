using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class RoomCheckInDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public string? Code { get; set; }

        public Guid? RelatedBookingId { get; set; }

        public RoomCheckInDto? RelatedBooking { get; set; }

        public Guid RoomId { get; set; }

        public RoomDto? Room { get; set; }

        public Guid? GuestId { get; set; }

        public GuestDto? Guest { get; set; }

        public DateTime EntryTime { get; set; }

        public DateTime ExitTime { get; set; }

        [NotMapped]
        public int Hour { get; set; }

        [NotMapped]
        public int Meridian { get; set; }

        [NotMapped]
        public string? NewGuest { get; set; }

        [NotMapped]
        public string? RelatedBookingCode { get; set; }

        public int Nights { get; set; }

        public int? Hours { get; set; }

        public Guid PaymentMethodId { get; set; }

        public PaymentMethodDto? PaymentMethod { get; set; }

        public double Amount { get; set; }

        public double ChargedAmount { get; set; }

        public string? VoucherNumber { get; set; }
    }
}
