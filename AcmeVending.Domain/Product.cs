using System.ComponentModel.DataAnnotations;

namespace AcmeVending.Domain
{
    public class Product
    {
        
        [Required()]
        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}