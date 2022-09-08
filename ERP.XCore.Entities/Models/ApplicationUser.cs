using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public Guid StatusId { get; set; }

        public Status? Status { get; set; }
    }
}
