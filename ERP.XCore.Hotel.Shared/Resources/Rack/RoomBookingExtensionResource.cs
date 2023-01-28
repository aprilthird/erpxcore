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

        public Guid PaymentMethodId { get; set; }

		public string? VoucherNumber { get; set; }

		public double? ChargedAmount { get; set; }

		public double? Amount { get; set; }
	}
}
