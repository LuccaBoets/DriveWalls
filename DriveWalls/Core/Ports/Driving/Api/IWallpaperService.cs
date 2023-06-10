using Core.Dto;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ports.Driving.Api
{
    public interface IWallpaperService : IService<Wallpaper>
    {
        Task<Wallpaper> Create(Wallpaper @object, String url);
    }
}
