using SampleAssignment.Api.Containers;

namespace SampleAssignment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var configuration = builder.Configuration;

            builder.Services.AddServicesInAssembly(configuration);

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            //Enable Swagger and SwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample Assignment API v1"); });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}