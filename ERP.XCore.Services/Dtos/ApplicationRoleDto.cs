using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class ApplicationRoleDto : BaseEntityDto
    {
        public virtual ICollection<ApplicationUserRoleDto>? UserRoles { get; set; }
        public virtual ICollection<PermissionDto>? Permissions { get; set; }
    }
}
