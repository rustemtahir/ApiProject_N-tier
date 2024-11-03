using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDers.Service.Validations.Auth
{
    public class LoginDtoValidation:AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {

            RuleFor(r => r.UserName)
                .NotEmpty()
                .NotNull();
            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
