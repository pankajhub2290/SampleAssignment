using SampleAssignment.Application.Repositories;
using SampleAssignment.Domain.Entities;
using SampleAssignment.Infrastructure.Context;

namespace SampleAssignment.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }
    }
}
