using SampleAssignment.WebApp.Services;
using System.Reflection;

namespace SampleAssignment.WebApp.Containers
{
    public class RegisterAppResources : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddHttpClient<ICustomerService, CustomerService>(client =>
            {
                client.BaseAddress = new Uri(configuration[$"Api:SampleApi:Url"]);
            });
        }
    }
}
