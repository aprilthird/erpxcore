using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class Module
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public ICollection<SubModule>? SubModules { get; set; }
    }
}
