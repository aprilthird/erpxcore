using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class Permission : BaseEntity
    {
        public Guid Id { get; set; }

        public string ApplicationId { get; set; }

        public ApplicationRole? Role { get; set; }

        public Guid SubModuleId { get; set; }

        public SubModule? SubModule { get; set; }

        public Guid PermissionLevelId { get; set; }

        public PermissionLevel? PermissionLevel { get; set; }
    }
}
