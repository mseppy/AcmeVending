using AcmeVending.Domain;
using AcmeVending.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace AcmeVending.Services
{
    public class PaymentService : IPaymentService
    {

        public decimal SubmitCashPayment(ICollection<Cash> payment)
        {
            throw new NotImplementedException();
        }

        public decimal SubmitCreditPayment(string creditCardNumber)
        {
            throw new NotImplementedException();
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
