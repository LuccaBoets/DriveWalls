using Core.Api.Service;
using Core.Models;
using Core.Ports.Driving.Api;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("test")]
    public class WallpaperController : ControllerBase
    {
        private readonly IWallpaperService _wallpaperService;

        public WallpaperController(IWallpaperService wallpaperService)
        {
            _wallpaperService = wallpaperService;
        }

        [HttpGet(Name = "GetWallpaper")]
        public async Task<IEnumerable<Wallpaper>> Get()
        {
            await Console.Out.WriteLineAsync("GetWallpaper");
            return await _wallpaperService.GetAll();
        }
    }
}