using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using AcmeVending.Domain.Interfaces;
using AcmeVending.Models;
using AcmeVending.Services;

namespace AcmeVending.Controllers
{
    public class HomeController : Controller
    {
        IPaymentService PayService = new PaymentService();
        IProductService ProdService = new ProductService();

        public ActionResult Index()
        {
            ViewBag.Title = "ACME Vending";


            var inventory = new InventoryVM
            {
                Products = ProdService.LoadMachine()
                            .Select(p => new ProductVM
                            {
                                ItemNumber = p.ItemNumber,
                                Name = p.Name,
                                Price = p.Price,
                                Quantity = p.Quantity
                            }).ToList(),
                Cash = new List<CashVM>()
                    };

            var till = PayService.LoadMachine();
            foreach (var billOrCoin in till)
            {
                inventory.Cash.Add(new CashVM { Value = billOrCoin, Quantity = billOrCoin.Quantity });
            }

            return View(inventory);
        }

    }
}
