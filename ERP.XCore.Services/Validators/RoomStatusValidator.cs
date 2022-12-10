using ERP.XCore.Services.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Services.Validators
{
    public class RoomStatusValidator : AbstractValidator<RoomStatusDto>
    {
        public RoomStatusValidator() 
        {

        }
    }
}
