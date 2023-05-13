using Microsoft.OpenApi.Models;

namespace Adapter.Api
{
    public class ApiAdapter
    {
        private WebApplication _app;

        public ApiAdapter(String[] args, Action<IServiceCollection> options)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            options.Invoke(builder.Services);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DriveWall", Version = "v1" });
            });

            _app = builder.Build();

            _app.UseSwagger();
            _app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DriveWall V1");
                c.RoutePrefix = string.Empty;
            });

            _app.UseHttpsRedirection();

            _app.UseRouting();
            _app.UseAuthorization();

            _app.MapControllers();
        }

        public Task runAsync()
        {
            return _app.RunAsync();
        }
    }
}