using MediatR;
using MiniProjects.Interfaces;
using MiniProjects.Models;
namespace MiniProjects.MediaTR
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTaskByIdAsync(request.Id);
        }
    }

}
