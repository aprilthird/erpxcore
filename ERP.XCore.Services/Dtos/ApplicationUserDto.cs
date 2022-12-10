using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class ApplicationUserDto : BaseEntityDto
    {
        public Guid EmployeeId { get; set; }

        public EmployeeDto? Employee { get; set; }

        public Guid StatusId { get; set; }

        public StatusDto? Status { get; set; }

        [NotMapped]
        public Guid RoleId { get; set; }

        [NotMapped]
        public string? Password { get; set; }

        [NotMapped]
        public string? PasswordConfirm { get; set; }


    }
}
