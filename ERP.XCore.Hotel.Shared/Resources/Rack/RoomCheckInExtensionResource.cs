using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Hotel.Shared.Resources.Rack
{
    public class RoomCheckInExtensionResource
    {
        public Guid RoomCheckInId { get; set; }

        public DateTime ExitTime { get; set; }

        public int Hour { get; set; }

        public int Meridian { get; set; }
	}
}
