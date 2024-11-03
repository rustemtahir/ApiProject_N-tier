
using ApiDers.Service.DTOs.Product;
using ApiDers.Service.Extension;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDers.Service.Validations.Product
{
    public class ProductPostDtoValidation : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20);
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(10000);
            RuleFor(x=>x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x).NotNull().WithMessage("nOt nUlL")
                .NotEmpty().WithMessage("caNNot bE emPtY")
                .Custom((x, context) =>
            {
                if (!x.File.IsImage())
                {
                    context.AddFailure(nameof(IFormFile), "File is not an image");
                }
                if (!x.File.IsSize(5))
                {
                    context.AddFailure(nameof(IFormFile), "File size must be 5mb ");
                }

            });
                
                

        }
    }
}
