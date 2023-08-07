using MediatR;
using SampleAssignment.Shared.Models;

namespace SampleAssignment.Application.Queries.GetAllCustomers
{
    public class GetAllCustomerQuery : IRequest<List<CustomerResponseModel>>
    {
    }
}
