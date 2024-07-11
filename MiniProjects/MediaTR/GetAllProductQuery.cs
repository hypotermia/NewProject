using MediatR;
using MiniProjects.Models;
namespace MiniProjects.MediaTR
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }

}
