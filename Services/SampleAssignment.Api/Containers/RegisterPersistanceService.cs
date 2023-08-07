using Microsoft.EntityFrameworkCore;
using SampleAssignment.Application.Repositories;
using SampleAssignment.Infrastructure.Context;
using SampleAssignment.Infrastructure.Repositories;

namespace SampleAssignment.Api.Containers
{
    public class RegisterPersistanceService : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:SqlDb"]);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
