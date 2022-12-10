using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class WorkAreaDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}
