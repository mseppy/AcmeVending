using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using AcmeVending.Domain.Interfaces;
using AcmeVending.Models;
using AcmeVending.Services;
using System;
using AcmeVending.Domain;

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
                                Price = p.Price.ToString("c"),
                                Quantity = p.Quantity
                            }).ToList(),
                Cash = new List<CashVM>()
            };

            var till = PayService.LoadMachine();
            //foreach (var billOrCoin in till)
            //{
            //    inventory.Cash.Add(new CashVM { Value = billOrCoin.Value.ToString("c"), Quantity = billOrCoin.Quantity });
            //}

            return View(inventory);
        }


        [HttpPost]
        public JsonResult BuyProduct(PurchaseVM purchase)
        {
            var cc = new CreditCard();

            var expDate = new DateTime(int.Parse(purchase.ExpDate.Substring(0, 2)),
                                        int.Parse(purchase.ExpDate.Substring(2, 2)),
                                        int.Parse(purchase.ExpDate.Substring(4, 2)));

            if (purchase.CreditType != "")
            {
                cc = new CreditCard
                {
                    CreditType = purchase.CreditType,
                    CardNumber = purchase.CardNumber,
                    ExpDate = expDate,
                    NameOnCard = purchase.NameOnCard
                };
            }
            InventoryResult result;
            try
            {
                result = ProdService.BuyProduct(purchase.ProductId, purchase.Cash, cc);
            }
            catch (Exception error)
            {
                return new JsonResult { Data = "Error: " + error.Message };
            }

            return new JsonResult { Data = result };
        }
    }
}
