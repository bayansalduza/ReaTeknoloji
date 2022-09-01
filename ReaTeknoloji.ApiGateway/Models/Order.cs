namespace ReaTeknoloji.ApiGateway.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
