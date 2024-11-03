using ApiDers.Service.DTOs;
using ApiDers.Service.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDers.Service.Validations
{
    public class RegisterDtoValidation :AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(r => r.UserName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30);
            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty()
               .EmailAddress().WithMessage("Email is not valid");
            RuleFor(r => r)
                .NotEmpty()
                .NotNull()
                .Custom((p, context) =>
                {
                    if (p.Password != p.ConfirmPassword)
                    {
                        context.AddFailure(p.ConfirmPassword, "Password do not match");
                    }
                });


        }
    }
}
