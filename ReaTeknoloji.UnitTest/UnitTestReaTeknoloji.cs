using Xunit;

namespace ReaTeknoloji.UnitTest
{
    public class UnitTestReaTeknoloji
    {
        [Theory]
        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var primeService = new Controllers.CustomerController();
            bool result = primeService.CreateCustomer(new Data.Dto.AddCustomerRequestDto() { AddressId = )

            Assert.False(result, "1 should not be prime");
        }
    }
}
