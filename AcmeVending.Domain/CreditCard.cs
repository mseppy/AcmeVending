
using System;

namespace AcmeVending.Domain
{
    public class CreditCard
    {
        public string CreditType { get; set; }
        public DateTime ExpDate { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
    }
}
