//using Adapter.Api;
//using Core.Api.Service;
//using Core.Ports.Driving.Api;
//using Database.Repository;
//using Microsoft.Extensions.DependencyInjection;

//var api = new AdapterApi(args, options =>
//{
//    options.AddScoped<IWallpaperService, WallpaperService>();
//    options.AddScoped<IWallpaperMetadataService, WallpaperMetadataService>();
//    options.AddScoped<IMetadataService, MetadataService>();
//    options.AddScoped<IWallpaperRepository, WallpaperRepository>();
//});

//await api.RunAsync();

Adapter.Api.Program.Main(args);