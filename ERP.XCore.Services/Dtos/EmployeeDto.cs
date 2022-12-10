using ERP.XCore.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Dtos
{
    public class EmployeeDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? WorkAreaId { get; set; }

        public WorkAreaDto? WorkArea { get; set; }

        public Guid? WorkPositionId { get; set; }

        public WorkPositionDto? WorkPosition { get; set; }

        public Guid? DocumentTypeId { get; set; }

        public DocumentTypeDto? DocumentType { get; set; }

        public string? Document { get; set; }

        public string? Address { get; set; }

        public Guid? UbigeoId { get; set; }

        public UbigeoDto? Ubigeo { get; set; }

        public Guid StatusId { get; set; }

        public StatusDto? Status { get; set; }

        public Guid CompanyId { get; set; }

        public CompanyDto? Company { get; set; }

        public string FullName => $"{LastName}, {FirstName}";

        public ICollection<ApplicationUserDto>? Users { get; set; }
    }
}
