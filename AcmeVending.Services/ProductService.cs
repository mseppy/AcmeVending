using AcmeVending.Domain;
using AcmeVending.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeVending.Services
{
    public class ProductService: IProductService
    {
        IList<Product> products;
        public IList<Product> ProductRepo
        {
            get { return products ?? CreateDummyData(); }
            set { products = value; }
        }

        IPaymentService payments;
        public IPaymentService PaymentServices
        {
            get { return payments ?? new PaymentService(); }
            set { payments = value; }
        }


        ICollection<Product> IProductService.LoadMachine()
        {
            ProductRepo = CreateDummyData();
            return ProductRepo; 
        }

        public Product SelectProduct(int itemId)
        {
            return ProductRepo.FirstOrDefault(p => p.ItemNumber == itemId);                       
        }

        public InventoryResult BuyProduct(int prodId, decimal cash, CreditCard credit)
        {
            if (credit == null) { BuyProduct(prodId, cash); }

            var result = new InventoryResult { Result = true };

            products = ProductRepo;

            var product = products.FirstOrDefault(p => p.ItemNumber == prodId);
            if (product == null || product.Quantity == 0)
            {
                result.Result = false;
                result.Message = "SOLD OUT";
                return result;
            }

            var ccTrans = PaymentServices.SubmitCreditPayment(credit, product.Price);

            if (ccTrans.Result)
            {
                product.Quantity--;
            }

            result.Change = cash;
            result.Message = ccTrans.Message;

            return result;
        }
        public InventoryResult BuyProduct(int prodId, decimal cash)
        {
            var result = new InventoryResult { Result = true };

            products = ProductRepo;

            var product = products.FirstOrDefault(p=>p.ItemNumber==prodId);
            if (product == null || product.Quantity == 0) 
            {
                result.Result = false;
                result.Message = "SOLD OUT";
                return result;
            }

            var cashTrans = PaymentServices.SubmitCashPayment(cash, product.Price);

            if (cashTrans.Result)
            {
                product.Quantity--;
            }

            result.Change = cashTrans.Change;
            result.Message = cashTrans.Message;

            return result;
        }

        IList<Product> CreateDummyData()
        {
            var products = new List<Product>();
            
            var random = new Random((int)DateTime.Now.Ticks);
            for (var i = 1; i < 11; i++)
            {
                decimal randPrice = i * 17 / 3;
                var roundTo5 = randPrice % 5;
                randPrice -= roundTo5;
                randPrice = Math.Round(randPrice / 10M, 2);

                var prodNumber = i + 3 + i * 2;
                products.Add(new Product
                    {
                        ItemNumber = prodNumber,
                        Name = "Product " + i,
                        Price = randPrice,
                        Quantity = 5
                    });
            }
            return products;
        }
    }
}
