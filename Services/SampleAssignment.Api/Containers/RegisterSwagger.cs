using Microsoft.OpenApi.Models;

namespace SampleAssignment.Api.Containers
{
    public class RegisterSwagger : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            //Register Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample Assignment API", Version = "v1" });
                options.CustomSchemaIds(type => type.ToString());

            });
        }
    }
}
