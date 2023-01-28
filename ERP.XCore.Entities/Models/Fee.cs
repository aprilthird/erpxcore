using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
	public class Fee : BaseEntity
	{
		public Guid Id { get; set; }

		public Guid RoomTypeId { get; set; }
		
		public RoomType? RoomType { get; set; }

		public Guid FeeTypeId { get; set; }

		public FeeType? FeeType { get; set; }

		public Guid StatusId { get; set; }

		public Status? Status { get; set; }
		
		public double Amount { get; set; }
	}
}
