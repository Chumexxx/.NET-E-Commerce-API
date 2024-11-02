namespace ECommerce.Helpers
{
    public class Bill
    {
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, int> CustomerBill { get; set; } = new Dictionary<string, int>(); 
        public decimal TotalBill { get; set; } 
    }
}
