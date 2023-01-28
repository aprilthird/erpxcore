using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class RoomCheckInCompanionDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public Guid RoomCheckInId { get; set; }

        public RoomCheckInDto RoomCheckIn { get; set; }

        public Guid GuestId { get; set; }

        public GuestDto Guest { get; set; }
    }
}
