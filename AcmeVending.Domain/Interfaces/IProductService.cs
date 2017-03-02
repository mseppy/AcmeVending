using System.Collections.Generic;

namespace AcmeVending.Domain.Interfaces
{
    public interface IProductService
    {
        ICollection<Product> LoadMachine();

        Product SelectProduct(int itemId);
        InventoryResult BuyProduct(int prodId, decimal cash);
    }
}
