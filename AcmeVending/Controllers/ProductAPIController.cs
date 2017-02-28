using AcmeVending.Domain.Interfaces;
using AcmeVending.Domain;
using AcmeVending.Models;
using AcmeVending.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AcmeVending.Controllers
{
    public class ProductAPIController : ApiController
    {
        ICollection<ProductVM> products = new List<ProductVM>();
        IProductService ProdService = new ProductService();

        public ProductAPIController()
        {
            products = ProdService.LoadMachine()
                        .Select(p=> new ProductVM
                        {
                            ItemNumber = p.ItemNumber,
                            Name = p.Name,
                            Price = p.Price,
                            Quantity = p.Quantity                           
                        }).ToList();
        }

        // GET api/values
        public IEnumerable<ProductVM> Get()
        {
            return products;
        }

        // GET api/values/5
        public ProductVM Get(int id)
        {
            return products.FirstOrDefault(p => p.ItemNumber == id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
