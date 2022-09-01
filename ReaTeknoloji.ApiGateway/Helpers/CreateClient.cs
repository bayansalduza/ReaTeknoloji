using Newtonsoft.Json;
using ReaTeknoloji.ApiGateway.Models;
using ReaTeknoloji.ApiGateway.Properties;
using System.Text;

namespace ReaTeknoloji.ApiGateway.Helpers
{
    public class CreateClient
    {
        private string REA_TEKNOLOJI_API_URL = Resources.ReaTeknolojiApiUrl;
        private string APPLICATION_JSON_HEADER = "application/json";
        HttpClient client = new HttpClient();

        public async Task<Response<string>> CreateCustomerAsync(AddCustomerRequestDto requestDto)
        {
            var json = new StringContent(JsonConvert.SerializeObject(requestDto), Encoding.UTF8, APPLICATION_JSON_HEADER);
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Customer/CreateCustomer";
            var response = await client.PostAsync(url, json);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<string>>(data);
            return result;
        }

        public async Task<Response<ValidateResponse>> ValidateAsync(string email, string password)
        {
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Customer/Validate/?email={email}&password={password}";
            var response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<ValidateResponse>>(data);
            return result;
        }

        public async Task<Response<string>> UpdateCustomerAsync(UpdateCustomerRequestDto requestDto)
        {
            var json = new StringContent(JsonConvert.SerializeObject(requestDto), Encoding.UTF8, APPLICATION_JSON_HEADER);
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Customer/UpdateCustomer";
            var response = await client.PutAsync(url, json);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<string>>(data);
            return result;
        }

        public async Task<Response<string>> DeleteCustomerAsync(int Id)
        {
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Customer/DeleteCustomer/?Id={Id}";
            var response = await client.DeleteAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<string>>(data);
            return result;
        }

        public async Task<Response<GetCustomerResponse>> GetCustomerAsync(int Id)
        {
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Customer/GetCustomer/?Id={Id}";
            var response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<GetCustomerResponse>>(data);
            return result;
        }

        public async Task<Response<List<Customer>>> GetCustomerAllAsync()
        {
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Customer/GetCustomerAll";
            var response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<List<Customer>>>(data);
            return result;
        }

        public async Task<Response<string>> CreateOrderAsync(AddOrderRequestDto requestDto)
        {
            var json = new StringContent(JsonConvert.SerializeObject(requestDto), Encoding.UTF8, APPLICATION_JSON_HEADER);
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Order/CreateOrder";
            var response = await client.PostAsync(url, json);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<string>>(data);
            return result;
        }

        public async Task<Response<string>> UpdateOrderAsync(UpdateOrderRequestDto requestDto)
        {
            var json = new StringContent(JsonConvert.SerializeObject(requestDto), Encoding.UTF8, APPLICATION_JSON_HEADER);
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Order/UpdateOrder";
            var response = await client.PutAsync(url, json);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<string>>(data);
            return result;
        }

        public async Task<Response<string>> DeleteOrderAsync(int Id)
        {
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Order/DeleteOrder/?Id={Id}";
            var response = await client.DeleteAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<string>>(data);
            return result;
        }

        public async Task<Response<List<Order>>> GetOrderAllAsync()
        {
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Order/GetOrderAll";
            var response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<List<Order>>>(data);
            return result;
        }
        public async Task<Response<List<Order>>> GetOrderByCustomer(int Id)
        {
            var url = $"{REA_TEKNOLOJI_API_URL}/api/Order/GetOrderByCustomer?customerId={Id}";
            var response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response<List<Order>>>(data);
            return result;
        }
    }
}
