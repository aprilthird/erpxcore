using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class RoomCheckIn : BaseEntity
    {
        public Guid Id { get; set; }

        public string? Code { get; set; }

        [Column("RelatedBookingId")]
        public Guid? RelatedCheckInId { get; set; }

        public RoomCheckIn? RelatedCheckIn { get; set; }

        public Guid RoomId { get; set; }

        public Room? Room { get; set; }

        public Guid? GuestId { get; set; }

        public Guest? Guest { get; set; }

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

        [NotMapped]
        public IEnumerable<Guid> CompanionIds { get; set; } = new List<Guid> { };

        [NotMapped]
        public IEnumerable<Guid> SelectedCompanionIds { get; set; } = new List<Guid> { };

        [NotMapped]
        public Guest[] SelectedCompanions { get; set; } = new Guest[] { };

        public int Nights { get; set; }

        public int? Hours { get; set; }

        public Guid PaymentMethodId { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public string? VoucherNumber { get; set; }

        public double? ChargedAmount { get; set; }

        public double? Amount { get; set; }

        public Guid? FeeId { get; set; }

        public Fee? Fee { get; set; }

        public Guid? StatusId { get; set; }

        public Status? Status { get; set; }

        public List<RoomCheckInDetail>? Details { get; set; }

        public List<RoomCheckInCompanion>? Companions { get; set; }
    }
}
