using DataAnnotationsExtensions;
using AcmeVending.Domain;

namespace AcmeVending.Models
{
    public class CashVM
    {
        public Cash Value { get; set; }

        [Min(0, ErrorMessage="There is no more of this denomination remaining.")]
        public int Quantity { get; set; }
    }
}