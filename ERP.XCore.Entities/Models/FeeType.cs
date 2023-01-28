using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
	public class FeeType : BaseEntity
	{
		public Guid Id { get; set; }

		public string Description { get; set; }

		public Guid CurrencyId { get; set; }

		public Currency? Currency { get; set; } 
	}
}
