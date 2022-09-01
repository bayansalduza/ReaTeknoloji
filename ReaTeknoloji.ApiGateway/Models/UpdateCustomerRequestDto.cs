namespace ReaTeknoloji.ApiGateway.Models
{
    public class UpdateCustomerRequestDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public string Password { get; set; }
    }
}
