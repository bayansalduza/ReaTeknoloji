namespace ReaTeknoloji.ApiGateway.Models
{
    public class AddOrderRequestDto
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int AddressId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
    }
}
