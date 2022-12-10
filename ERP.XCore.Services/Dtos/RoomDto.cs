using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class RoomDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid RoomTypeId { get; set; }

        public RoomTypeDto? RoomType { get; set; }

        public Guid RoomStatusId { get; set; }

        public RoomStatusDto? RoomStatus { get; set; }

        public Guid StatusId { get; set; }

        public StatusDto? Status { get; set; }
    }
}
