using AutoMapper;
using MediatR;
using SampleAssignment.Application.Commands.CreateCustomer;
using SampleAssignment.Application.Repositories;
using SampleAssignment.Domain.Entities;
using SampleAssignment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAssignment.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CustomerResponseModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
           
            var customer = await _customerRepository.Get(request.Id, cancellationToken);

            if(customer != null)
            {
                customer.Phone = request.Phone;
                customer.Address.AddressLine1 = request.AddressLine1;
                customer.Address.AddressLine2 = request.AddressLine2;
                customer.Address.State = request.State;
                customer.Address.PostalCode = request.PostalCode;
                customer.Address.City = request.City;
                customer.Address.Country = request.Country;
                customer.Email = request.Email; 
                customer.ContactName = request.ContactName;
                _customerRepository.Update(customer);
            }

            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CustomerResponseModel>(customer);
        }
    }
}
