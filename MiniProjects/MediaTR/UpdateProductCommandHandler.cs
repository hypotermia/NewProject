using MediatR;
using MiniProjects.Models;
using MiniProjects.Interfaces;
using FluentValidation;
namespace MiniProjects.MediaTR
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        private readonly IValidator<Product> _validator;

        public UpdateProductCommandHandler(IProductRepository repository, IValidator<Product> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                ProductsName = request.ProductsName,
                ProductsPrices = request.ProductsPrices,
                Quantity = request.Quantity
            };

            var validationResult = await _validator.ValidateAsync(product, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _repository.UpdateTaskAsync(request.Id, product);
            return Unit.Value;
        }
    }

}
