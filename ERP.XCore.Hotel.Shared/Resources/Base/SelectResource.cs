using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Hotel.Shared.Resources.Base
{
    public class SelectResource<T>
    {
        public T Value { get; set; }

        public string Text { get; set; }
    }
}
