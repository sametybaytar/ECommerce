using ECommerceAPI.Application.ViewModels.Products;
using ECommerceAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ürün adı boş bırakılamaz")
                .MinimumLength(2)
                .MaximumLength(1000)
                    .WithMessage("Ürün adı 2 ile 1000 arasında olmalıdır");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ürün stok bilgisi boş bırakılamaz")
                .Must(p => p >= 0)
                    .WithMessage("Stok değeri pozitif olmalıdır");
            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ürün fiyat bilgisi boş bırakılamaz")
                .Must(p => p >= 0)
                    .WithMessage("Fiyat değeri pozitif olmalıdır");

        }
    }
}
