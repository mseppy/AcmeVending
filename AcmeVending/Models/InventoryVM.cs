using System.Collections.Generic;


namespace AcmeVending.Models
{
    public class InventoryVM
    {
        public IList<ProductVM> Products { get; set; }
        public IList<CashVM> Cash { get; set; }

    }
}