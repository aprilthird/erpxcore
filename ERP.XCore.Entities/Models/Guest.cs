using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class Guest : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid DocumentTypeId { get; set; }

        public DocumentType? DocumentType { get; set; }

        public string Document { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Guid UbigeoId { get; set; }

        public Ubigeo? Ubigeo { get; set; }

        public Guid StatusId { get; set; }

        public Status? Status { get; set; }
    }
}
