using AcmeVending.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AcmeVending.Controllers
{
    public class CaashController : ApiController
    {
        private IList<CashVM> till = new List<CashVM>();

        public CaashController()
        {
        }

        // GET api/values
        public IEnumerable<CashVM> Get()
        {
            return till;
        }

        // GET api/values/5
        public CashVM Get(string id)
        {
            return till.FirstOrDefault(c => c.Value == id);
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
        public void Delete(string id)
        {
            var billOrCoin = till.FirstOrDefault(c => c.Value == id);
            till.Remove(billOrCoin);
        }
    }
}
