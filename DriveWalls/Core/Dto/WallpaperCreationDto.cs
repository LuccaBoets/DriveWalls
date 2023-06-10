using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class WallpaperCreationDto
    {
        public String Name { get; set; }
        public String ImageUrl { get; set; }

        public Wallpaper GetWallpaper()
        {
            return new Wallpaper()
            {
                Name = this.Name,
                UploadDate = DateTime.Now
            };
        }
    }
}
