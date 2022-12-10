using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class PermissionDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public ApplicationRoleDto? Role { get; set; }

        public Guid SubModuleId { get; set; }

        public SubModuleDto? SubModule { get; set; }

        public Guid PermissionLevelId { get; set; }

        public PermissionLevelDto? PermissionLevel { get; set; }
    }
}
