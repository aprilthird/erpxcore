using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class ApplicationUserRoleDto : BaseEntityDto
    {
        public virtual ApplicationUserDto User { get; set; }

        public virtual ApplicationRoleDto Role { get; set; }
    }
}
