using Core.Api.Service;
using Core.Dto;
using Core.Models;
using Core.Ports.Driving.Api;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WallpaperController : ControllerBase
    {
        private readonly IWallpaperService _wallpaperService;

        public WallpaperController(IWallpaperService wallpaperService)
        {
            _wallpaperService = wallpaperService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _wallpaperService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WallpaperCreationDto wallpaper)
        {
            return Created(wallpaper.ImageUrl, await _wallpaperService.Create(wallpaper.GetWallpaper(), wallpaper.ImageUrl));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _wallpaperService.Delete(id);
            return Ok(id);
        }
    }
}