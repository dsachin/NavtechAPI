namespace ApiModels.Models.MultiModel
{
    public class OrderResponseModel 
    {
        public int Id { get; set; }        
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public double AmountPaid { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentType { get; set; }
    }
}
