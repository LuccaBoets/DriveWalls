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

        public override Wallpaper Create(Wallpaper @object)
        {
            storage.Save("");
            return base.Create(@object);
        }

        public override void Delete(Wallpaper @object)
        {
            storage.Delete(@object);
            base.Delete(@object);
        }
    }
}
