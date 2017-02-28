using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace AcmeVending.Models
{
    public class ProductVM
    {
        [Required()]
        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [Min(0, ErrorMessage="Sold Out!")]
        public int Quantity { get; set; }
    }
}