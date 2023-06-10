using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ports.Driving.Api
{
    public interface IWallpaperMetadataService
    {
        Task<List<Wallpaper>> GetAllByMetadata(int metadataId);
        Task<List<Wallpaper>> GetAllByMetadata(List<int> metadataIds, bool matchAll);
        Task<List<Metadata>> GetAllByWallpaper(string wallpaperId);

        Task<WallpaperMetadata> Create(WallpaperMetadata @object);
        void Delete(WallpaperMetadata @object);
    }
}
