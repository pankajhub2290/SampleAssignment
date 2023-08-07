using AutoMapper;
using MediatR;
using SampleAssignment.Application.Repositories;
using SampleAssignment.Shared.Models;

namespace SampleAssignment.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponseModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerResponseModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<CustomerResponseModel>(customer);
        }
    }
}
