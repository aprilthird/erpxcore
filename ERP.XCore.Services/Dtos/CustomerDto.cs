using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class CustomerDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid PersonTypeId { get; set; }

        public PersonTypeDto? PersonType { get; set; }

        public Guid DocumentTypeId { get; set; }

        public DocumentTypeDto? DocumentType { get; set; }

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

        public UbigeoDto? Ubigeo { get; set; }

        public Guid CompanyId { get; set; }

        public CompanyDto? Company { get; set; }

        public Guid StatusId { get; set; }

        public StatusDto? Status { get; set; }
    }
}
