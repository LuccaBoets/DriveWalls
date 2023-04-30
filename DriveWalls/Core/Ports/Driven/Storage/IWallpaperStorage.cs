using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ports.Driven.Storage
{
    public interface IWallpaperStorage
    {
        String Save(String uri);

        void Delete(Wallpaper wallpaper);
    }
}
