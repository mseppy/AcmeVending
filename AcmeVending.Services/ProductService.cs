using AcmeVending.Domain;
using AcmeVending.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeVending.Services
{
    public class ProductService: IProductService
    {
        private Dictionary<int,Product> products = new Dictionary<int, Product>();

        public ProductService()
        {
            //Dummy data
            var random = new Random((int)DateTime.Now.Ticks);
            for (var i = 1; i < 11; i++)
            {
                products.Add(i,
                    new Product
                {
                    ItemNumber = i,
                    Name = "Product " + i,
                    Price = Math.Round(random.Next(0, 63423) / 10000M, 2),
                    Quantity = 5
                });
            }
        }

        ICollection<Product> IProductService.LoadMachine()
        {
            return products.Select(p => p.Value).ToList();
        }


        Product IProductService.SelectProduct(int itemId)
        {
            return products.FirstOrDefault(p => p.Key == itemId).Value;                        
        }
    }
}
