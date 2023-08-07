using MediatR;
using SampleAssignment.Shared.Models;

namespace SampleAssignment.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponseModel>
    {
        public int Id { get; set; }
    }
}
