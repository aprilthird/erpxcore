using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class Ubigeo : BaseEntity
    {
        public Guid Id { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public string ProvinceName { get; set; }

        public string ProvinceCode { get; set; }

        public string DistrictCode { get; set; }

        public string DistrictName { get; set; }

        public string Citizenship { get; set; }
    }
}
