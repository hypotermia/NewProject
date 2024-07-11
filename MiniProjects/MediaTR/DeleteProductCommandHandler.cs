using MediatR;
using MiniProjects.Interfaces;

namespace MiniProjects.MediaTR
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteTaskAsync(request.Id);
            return Unit.Value;
        }
    }

}
