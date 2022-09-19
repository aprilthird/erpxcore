using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class Room
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid RoomTypeId { get; set; }

        public RoomType RoomType { get; set; }

        public Guid StatusId { get; set; }

        public Status Status { get; set; }
    }
}
