﻿using ERP.XCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Entities.Models
{
    public class CashRegister : BaseEntity
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}