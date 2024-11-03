using APIDers1.Service.DTOs;
using FluentValidation;

namespace APIDers1.Service.Validations.CategoryValidation
{
    public class CategoryPostDtoValidation:AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Item can not be null ")
                .NotNull().WithMessage("Item can not be empty")
                .MaximumLength(30)
                .MinimumLength(3);
        }
    }
}
