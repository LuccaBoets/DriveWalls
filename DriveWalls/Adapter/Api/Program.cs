public class ApiAdapter
{
    private WebApplication _app;

    public ApiAdapter(String[] args, Action<IServiceCollection> options)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        options.Invoke(builder.Services);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        _app = builder.Build();

        // Configure the HTTP request pipeline.
        if (_app.Environment.IsDevelopment())
        {
            _app.UseSwagger();
            _app.UseSwaggerUI();
        }

        _app.UseHttpsRedirection();

        _app.UseAuthorization();

        _app.MapControllers();
    }

    public Task runAsync()
    {
        return _app.RunAsync();
    }
}