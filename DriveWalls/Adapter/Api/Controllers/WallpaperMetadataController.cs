using Core.Api.Service;
using Core.Dto;
using Core.Models;
using Core.Ports.Driving.Api;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WallpaperMetadataController : ControllerBase
    {
        private readonly IWallpaperMetadataService _wallpaperMetadataService;

        public WallpaperMetadataController(IWallpaperMetadataService wallpaperMetadataService)
        {
            _wallpaperMetadataService = wallpaperMetadataService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            

            return null;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(WallpaperCreationDto wallpaper)
        //{
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //}
    }
}