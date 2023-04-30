using Microsoft.Extensions.DependencyInjection;

var api = new ApiAdapter(args, options =>
{
    //options.AddScoped<>();
});

await api.runAsync();