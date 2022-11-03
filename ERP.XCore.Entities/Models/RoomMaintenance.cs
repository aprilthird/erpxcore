using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class RoomMaintenance : BaseEntity
    {

        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public Room Room { get; set; }

        public Guid EmployeeId { get; set; }

        public Guest Employee { get; set; }

        public string Description { get; set; }

        public DateTime StartedAt { get; set; }
    }
}
