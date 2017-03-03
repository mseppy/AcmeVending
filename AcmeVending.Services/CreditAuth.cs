using System;
using AcmeVending.Domain.Interfaces;

namespace AcmeVending.Services
{
    public class CreditAuth : ICreditAuth
    {
        public string transactionRequest(decimal amount, string cardType, string cardNumber, DateTime expireDate)
        {

            if (string.IsNullOrWhiteSpace(cardNumber)
                || cardNumber.Length < 16)
            {
                return "INVALID";
            }

            return "APPROVED"
;        }
    }
}
