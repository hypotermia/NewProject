using System.ComponentModel.DataAnnotations;

namespace WebFrontEnd.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        
        
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string ProductsName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal ProductsPrices { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative integer")]
        public int quantity { get; set; }
    }
}
