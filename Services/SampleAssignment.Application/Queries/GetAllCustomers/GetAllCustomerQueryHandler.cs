using AutoMapper;
using MediatR;
using SampleAssignment.Application.Repositories;
using SampleAssignment.Shared.Models;

namespace SampleAssignment.Application.Queries.GetAllCustomers
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerResponseModel>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetAllCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerResponseModel>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll(cancellationToken);
            return _mapper.Map<List<CustomerResponseModel>>(customers);
        }
       
    }
}
