using AcmeVending.Domain;
using AcmeVending.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace AcmeVending.Services
{
    public class PaymentService : IPaymentService
    {
        ICreditAuth creditAuth;
        public ICreditAuth CreditAuthServices
        {
            get { return creditAuth ?? new CreditAuth (); }
            set { creditAuth = value; }
        }

        public InventoryResult SubmitCashPayment(ICollection<Cash> payment, decimal price)
        {
            throw new NotImplementedException();
        }

        public InventoryResult SubmitCashPayment(decimal payment, decimal price)
        {
            var result = new InventoryResult
            {
                Result = true,
                Message = "APPROVED",
                PayMethod = "cash",
            };


            if (payment < price)
            {
                result.Result = false;
                result.Message = "NSF";
                return result;
            }

            result.Change = payment - price;

            return result;
        }

        public InventoryResult SubmitCreditPayment(CreditCard creditCard, decimal price)
        {
            if(creditCard == null) { throw new ArgumentNullException("creditcard"); }

            var result = new InventoryResult
            {
                Result = true,
                PayMethod = "credit"
            };

            var ccprice = price * 1.05M;  // Add transaction fee
            try
            {
                var ccResult = CreditAuthServices.transactionRequest(ccprice, creditCard.CreditType, creditCard.CardNumber, creditCard.ExpDate);

                result.Message = ccResult;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ICollection<Cash> MakeChange(decimal amount)
        {
            throw new NotImplementedException();
        }

        ICollection<Cash> IPaymentService.LoadMachine()
        {
            var stacks = new List<Cash>();

            foreach (var denom in Cash.ValidValues)
            {
                stacks.Add(new Cash { Value = denom, Quantity = 5 });
            }
            return stacks;
        }
    }
}
