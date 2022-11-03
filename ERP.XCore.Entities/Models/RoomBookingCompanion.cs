using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class RoomBookingCompanion : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid RoomBookingId { get; set; }

        public RoomBooking RoomBooking { get; set; }

        public Guid GuestId { get; set; }

        public Guest Guest { get; set; }
    }
}
