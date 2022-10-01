using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class Customer : BaseEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid PersonTypeId { get; set; }

        public PersonType? PersonType { get; set; }

        public Guid DocumentTypeId { get; set; }

        public DocumentType? DocumentType { get; set; }

        public string Document { get; set; }

        public string Sex { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Direction { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public string Website { get; set; }

        public string MaritalStatus { get; set; }
        
        public bool RetentionAgent { get; set; }

        public Guid UbigeoId { get; set; }
        
        public Ubigeo? Ubigeo { get; set; }

        public Guid CompanyId { get; set; }

        public Company? Company { get; set; }

        public Guid StatusId { get; set; }

        public Status? Status { get; set; }
    }
}
