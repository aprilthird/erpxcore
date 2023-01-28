using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class RoomCheckInCompanion : BaseEntity
    {
        public Guid Id { get; set; }

        [Column("RoomBookingId")]
        public Guid RoomCheckInId { get; set; }

        public RoomCheckIn RoomCheckIn { get; set; }

        public Guid GuestId { get; set; }

        public Guest Guest { get; set; }
    }
}
