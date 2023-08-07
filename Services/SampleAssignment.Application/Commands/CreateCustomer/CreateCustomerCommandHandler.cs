using AutoMapper;
using MediatR;
using SampleAssignment.Application.Repositories;
using SampleAssignment.Domain.Entities;
using SampleAssignment.Shared.Models;

namespace SampleAssignment.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CustomerResponseModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            customer.SetAddress(new Domain.Common.Address(request.AddressLine1, request.AddressLine2, request.City, request.State, request.Country, request.PostalCode));
            _customerRepository.Create(customer);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CustomerResponseModel>(customer);
        }
    }
}
