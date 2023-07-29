using Core.Models;
using Core.Ports.Driving.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Service
{
    public class WallpaperMetadataService : IWallpaperMetadataService
    {
        public IWallpaperMetadataRepository repository { get; set; }

        public WallpaperMetadataService(IWallpaperMetadataRepository repository)
        {
            this.repository = repository;
        }

        public Task<WallpaperMetadata> Create(WallpaperMetadata @object)
        {
            return repository.Create(@object);
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }

        // TODO: logic should maybe go to repository, but i am not sure
        // TODO: maybe should be IEnumerable instead of List
        public async Task<List<Wallpaper>> GetAllByMetadata(int metadataId)
        {
            var wallpapers = await repository.GetAll();
            return wallpapers.Where(w => w.Metadata.Id == metadataId).Select(w => w.Wallpaper).ToList();
        }

        public async Task<List<Wallpaper>> GetAllByMetadata(List<int> metadataIds, bool matchAll)
        {
            var wallpapers = await repository.GetAll();
            if (matchAll)
            {
                foreach (var id in metadataIds)
                {
                    wallpapers = wallpapers.Where(w => w.Metadata.Id == id).ToList();
                }
            }
            else
            {
                wallpapers = wallpapers.Where(w => metadataIds.Contains(w.Metadata.Id)).ToList();
            }
            return wallpapers.Select(w => w.Wallpaper).ToList();
        }

        public async Task<List<Metadata>> GetAllByWallpaper(string wallpaperId)
        {
            var wallpapers = await repository.GetAll();
            return wallpapers.Where(w => w.Wallpaper.Id == wallpaperId).Select(w => w.Metadata).ToList();
        }
    }
}
