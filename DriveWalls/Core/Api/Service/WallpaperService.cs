using Core.Models;
using Core.Ports.Driven.Storage;
using Core.Ports.Driving.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Service
{
    public class WallpaperService : Service<Wallpaper>, IWallpaperService
    {
        private IWallpaperStorage storage;

        public WallpaperService(IWallpaperRepository repository, IWallpaperStorage storage) : base(repository)
        {
            this.storage = storage;
        }
        
        public override Task<Wallpaper> Create(Wallpaper @object)
        {
            throw new NotImplementedException();
        }

        public async Task<Wallpaper> Create(Wallpaper @object, String url)
        {
            @object.Id = storage.Save(url);
            return await base.Create(@object);
        }

        public override void Delete(string id)
        {
            storage.Delete(id);
            base.Delete(id);
        }
    }
}
