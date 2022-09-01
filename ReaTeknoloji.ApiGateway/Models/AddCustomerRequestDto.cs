namespace ReaTeknoloji.ApiGateway.Models
{
    public class AddCustomerRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AddressId { get; set; }
    }
}
