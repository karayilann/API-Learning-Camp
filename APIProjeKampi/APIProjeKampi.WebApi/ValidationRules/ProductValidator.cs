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

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı girilmesi zorunludur.")
                .LessThan(0).WithMessage("Ürün fiyatı negatif olamaz")
                .GreaterThan(10000).WithMessage("Ürün fiyatı 10.000'den yüksek olamaz");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürüne ait açıklama girmek zorunludur.")
                .MinimumLength(3).WithMessage("Ürüne ait açıklama isminden kısa olamaz");

        }

    }
}
