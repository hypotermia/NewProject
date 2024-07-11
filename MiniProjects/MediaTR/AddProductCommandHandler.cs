using FluentValidation;
using MediatR;
using MiniProjects.Interfaces;
using MiniProjects.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MiniProjects.MediaTR
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand,Unit>
    {
        private readonly IProductRepository _repository;
        private readonly IValidator<Product> _validator;
        public AddProductCommandHandler(IProductRepository repository , IValidator<Product> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductsName = request.ProductsName,
                ProductsPrices = request.ProductsPrices,
                Quantity = request.Quantity
            };

            var validationResult = await _validator.ValidateAsync(product, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _repository.AddTaskAsync(product);
            return Unit.Value;
        }
    }
}
