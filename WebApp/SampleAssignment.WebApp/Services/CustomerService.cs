using SampleAssignment.Shared.Models;
using System.Text;
using System.Text.Json;

namespace SampleAssignment.WebApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CustomerResponseModel> CreateCustomer(CustomerRequestModel customer)
        {
            var uri = "customer";
            var content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error in creating customer");
            }

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CustomerResponseModel>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var uri = $"customer/{id}";

            var responseString = await _httpClient.DeleteAsync(uri);

            var jsonString = await responseString.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<CustomerResponseModel> GetCustomerById(int id)
        {
            var uri = $"customer/{id}";

            var responseString = await _httpClient.GetStringAsync(uri);

            var response = JsonSerializer.Deserialize<CustomerResponseModel>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return response;
        }

        public async Task<List<CustomerResponseModel>> GetCustomers()
        {
            var uri = "customer";

            var responseString = await _httpClient.GetStringAsync(uri);

            var response = JsonSerializer.Deserialize<List<CustomerResponseModel>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return response;
        }

        public async Task<CustomerResponseModel> UpdateCustomer(int id, CustomerRequestModel customer)
        {
            var uri = $"customer/{id}";
            var content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error in updating customer");
            }

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CustomerResponseModel>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
