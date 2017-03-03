using System.Collections.Generic;

namespace AcmeVending.Domain.Interfaces
{
    public interface IPaymentService
    {
        InventoryResult SubmitCashPayment(ICollection<Cash> payment, decimal price);
        InventoryResult SubmitCashPayment(decimal cash, decimal price);
        InventoryResult SubmitCreditPayment(CreditCard creditCard, decimal price);

        ICollection<Cash> MakeChange(decimal amount);
        ICollection<Cash> LoadMachine();
    }
}
