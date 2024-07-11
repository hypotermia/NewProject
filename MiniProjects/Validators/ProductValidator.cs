using FluentValidation;
using MiniProjects.Models;

namespace MiniProjects.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductsName).NotEmpty().WithMessage("Product name is required.");
            RuleFor(p => p.ProductsPrices).GreaterThan(0).WithMessage("Product price must be greater than 0.");
            RuleFor(p => p.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity must be 0 or greater.");
        }
    }
}
