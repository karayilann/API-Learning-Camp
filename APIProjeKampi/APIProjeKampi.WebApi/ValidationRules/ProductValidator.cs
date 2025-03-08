using APIProjeKampi.WebApi.Entities;
using FluentValidation;

namespace APIProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {

        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı girilmesi zorunludur");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("En az 2 karakter girilmelidir.");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("En fazla 50 karakter girilebilir");

        }

    }
}
