using AutoMapper;
using MediatR;
using SampleAssignment.Application.Repositories;

namespace SampleAssignment.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(request.Id, cancellationToken);

            if (customer != null)
            {
                _customerRepository.Delete(customer);
            }
            await _unitOfWork.Save(cancellationToken);

            return true;
        }
    }
}
