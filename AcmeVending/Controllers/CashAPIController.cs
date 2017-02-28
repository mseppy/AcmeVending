using AcmeVending.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AcmeVending.Controllers
{
    public class ValuesController : ApiController
    {
        private IList<ProductVM> products = new List<ProductVM>();

        public ValuesController()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            for (var i = 1; i < 11; i++)
            {
                products.Add(new ProductVM
                {
                    ItemNumber = i,
                    Name = "Product " + i,
                    Price = Math.Round(random.Next(0, 63423) / 10000M, 2),
                    Quantity = 5
                });
            }
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
