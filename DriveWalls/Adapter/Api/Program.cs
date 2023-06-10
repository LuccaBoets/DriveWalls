namespace Adapter.Api
{

    public class Program
    {
        public static void Main(string[] args, Action<IServiceCollection> options)
        {
            CreateHostBuilder(args, options).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, Action<IServiceCollection> options) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, test) =>
                {
                    options.Invoke(test);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}