using MediatR;

namespace MiniProjects.MediaTR
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string ProductsName { get; set; }
        public decimal ProductsPrices { get; set; }
        public int Quantity { get; set; }
    }

}
