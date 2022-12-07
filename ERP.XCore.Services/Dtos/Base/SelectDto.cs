using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos.Base
{
	public class SelectDto<T>
	{
		public T Value { get; set; }

		public string Text { get; set; }
	}
}
