
using MediatR;

namespace MiniProjects.MediaTR
{
    public class AddProductCommand : IRequest<Unit>
    {
        public string ProductsName { get; set; }
        public decimal ProductsPrices { get; set; }
        public int Quantity { get; set; }
    }
}
