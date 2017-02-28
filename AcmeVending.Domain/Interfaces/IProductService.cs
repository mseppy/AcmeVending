using System.Collections.Generic;

namespace AcmeVending.Domain.Interfaces
{
    public interface IProductService
    {
        Product SelectProduct(int itemId);

        ICollection<Product> LoadMachine();
    }
}
