using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class Employee : BaseEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? WorkAreaId { get; set; }

        public WorkArea? WorkArea { get; set; }

        public Guid? WorkPositionId { get; set; }

        public WorkPosition? WorkPosition { get; set; }

        public Guid? DocumentTypeId { get; set; }

        public DocumentType? DocumentType { get; set; }

        public string? Document { get; set; }

        public string? Address { get; set; }

        public Guid? UbigeoId { get; set; }

        public Ubigeo? Ubigeo { get; set; }

        public Guid StatusId { get; set; }

        public Status? Status { get; set; }

        public Guid CompanyId { get; set; }

        public Company? Company { get; set; }

        public string FullName => $"{LastName}, {FirstName}";

        public ICollection<ApplicationUser>? Users { get; set; }
    }
}
