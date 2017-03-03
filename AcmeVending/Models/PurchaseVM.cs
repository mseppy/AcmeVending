namespace AcmeVending.Models
{
    public class PurchaseVM
    {
        public int ProductId { get; set; }
        public decimal Cash { get; set; }
        public string CreditType { get; set; }
        public string ExpDate { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
    }
}