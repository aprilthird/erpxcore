using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public  class RoomCleaningDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public RoomDto? Room { get; set; }

        public Guid EmployeeId { get; set; }

        public EmployeeDto? Employee { get; set; }

        public DateTime? StartedAt { get; set; }
    }
}
