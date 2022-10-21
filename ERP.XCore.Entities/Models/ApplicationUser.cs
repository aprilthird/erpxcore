using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public Guid StatusId { get; set; }

        public Status? Status { get; set; }

        [NotMapped]
        public Guid RoleId { get; set; }

        [NotMapped]
        public string? Password { get; set; }

        [NotMapped]
        public string? PasswordConfirm { get; set; }

        public virtual ICollection<ApplicationUserClaim>? Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin>? Logins { get; set; }
        public virtual ICollection<ApplicationUserToken>? Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }
    }
}
