namespace WebFrontEnd.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPerTrx { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
