using MediatR;
namespace MiniProjects.MediaTR
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
