using MediatR;
using MiniProjects.Models;
namespace MiniProjects.MediaTR
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }

}
