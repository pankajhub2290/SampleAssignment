using Microsoft.Extensions.DependencyInjection;
using SampleAssignment.Application.Queries.GetAllCustomers;
using System.Reflection;

namespace SampleAssignment.Api.Containers
{
    public class RegisterApplicationServices : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(serviceConfiguration =>
                serviceConfiguration.RegisterServicesFromAssemblies(new[] { typeof(GetAllCustomerQueryHandler).Assembly }));
            //services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
