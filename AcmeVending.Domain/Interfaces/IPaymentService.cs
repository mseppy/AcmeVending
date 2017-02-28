using System.Collections.Generic;

namespace AcmeVending.Domain.Interfaces
{
    public interface IPaymentService
    {
        decimal SubmitCashPayment(ICollection<Cash> payment);
        decimal SubmitCreditPayment(string creditCardNumber);

        ICollection<Cash> MakeChange(decimal amount);
        ICollection<Cash> LoadMachine();
    }
}
