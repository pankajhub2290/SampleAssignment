using AutoMapper;
using SampleAssignment.Application.Commands.CreateCustomer;
using SampleAssignment.Application.Commands.UpdateCustomer;
using SampleAssignment.Domain.Common;
using SampleAssignment.Domain.Entities;
using SampleAssignment.Shared.Models;

namespace SampleAssignment.Api.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<CustomerRequestModel, CreateCustomerCommand>();
            CreateMap<CustomerRequestModel, UpdateCustomerCommand>();
            CreateMap<Customer, CustomerResponseModel>();
            CreateMap<Address, AddressResponseModel>();

            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
        }
    }
}
