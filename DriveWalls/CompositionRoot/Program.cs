﻿using Core.Api.Service;
using Core.Ports.Driven.Storage;
using Core.Ports.Driving.Api;
using Database.Repository;
using Microsoft.Extensions.DependencyInjection;
using Storage;

var options = new Action<IServiceCollection>(services =>
{
    services.AddScoped<IWallpaperService, WallpaperService>();
    
    services.AddScoped<IWallpaperMetadataService, WallpaperMetadataService>();
    
    services.AddScoped<IMetadataService, MetadataService>();
    services.AddScoped<IMetadataRepository, MetadataRepository>();
    
    services.AddScoped<IWallpaperStorage, WallpaperStorage>();
    services.AddScoped<IWallpaperRepository, WallpaperRepository>();
});

Adapter.Api.Program.Main(args, options);