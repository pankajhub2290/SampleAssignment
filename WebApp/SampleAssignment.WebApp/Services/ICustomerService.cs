using SampleAssignment.Shared.Models;

namespace SampleAssignment.WebApp.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerResponseModel>> GetCustomers();
        Task<CustomerResponseModel> GetCustomerById(int id);
        Task<CustomerResponseModel> CreateCustomer(CustomerRequestModel customer);
        Task<CustomerResponseModel> UpdateCustomer(int id, CustomerRequestModel customer);
        Task<bool> DeleteCustomer(int id);
    }
}
