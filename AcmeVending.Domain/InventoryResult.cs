namespace AcmeVending.Domain
{
    public class InventoryResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public decimal Change { get; set; }
        public string PayMethod { get; set; }
    }
}