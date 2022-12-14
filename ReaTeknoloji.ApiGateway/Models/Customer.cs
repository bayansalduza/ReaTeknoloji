namespace ReaTeknoloji.ApiGateway.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public string? CurrentToken { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
