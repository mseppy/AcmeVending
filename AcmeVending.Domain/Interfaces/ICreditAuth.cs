using System;

namespace AcmeVending.Domain.Interfaces
{
    public interface ICreditAuth
    {
         string transactionRequest(decimal amount, string cardType, string cardnumber,  DateTime expireDate);
    }
}
