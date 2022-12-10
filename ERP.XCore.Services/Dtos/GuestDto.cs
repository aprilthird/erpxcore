using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class GuestDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public Guid DocumentTypeId { get; set; }

        public DocumentTypeDto? DocumentType { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public Guid? UbigeoId { get; set; }

        public UbigeoDto? Ubigeo { get; set; }

        public Guid StatusId { get; set; }

        public StatusDto? Status { get; set; }

        public string FullName => $"{LastName}, {FirstName}";
    }
}
