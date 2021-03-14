namespace Navtech.Models
{
    public class OrderProductModel
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public string Products { get; set; }
    }
}
