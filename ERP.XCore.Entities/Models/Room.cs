using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class Room : BaseEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid RoomTypeId { get; set; }

        public RoomType? RoomType { get; set; }

        public Guid RoomStatusId { get; set; }

        public RoomStatus? RoomStatus { get; set; }

        public Guid StatusId { get; set; }

        public Status? Status { get; set; }
    }
}
