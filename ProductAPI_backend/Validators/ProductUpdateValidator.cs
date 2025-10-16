using FluentValidation;
using ProductAPI_backend.DTOs;

namespace ProductAPI_backend.Validators
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDTO>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(dto => dto.Price).GreaterThan(0).WithMessage("El precio debe ser mayor a cero");
            RuleFor(dto => dto.Stock).GreaterThanOrEqualTo(0).WithMessage("El stock debe ser mayor o igual a cero");
        }
    }
}
