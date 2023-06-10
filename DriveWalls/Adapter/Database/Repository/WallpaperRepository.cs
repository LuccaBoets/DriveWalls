using Core.Models;
using Core.Ports.Driving.Api;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Database.Repository
{
    public class WallpaperRepository : IWallpaperRepository
    {
        public IFirebaseClient _client { get; set; }

        public WallpaperRepository()
        {
            _client = DatabaseClient.GetClient();
        }

        public async Task<Wallpaper> Create(Wallpaper @object)
        {
            var temp = _client.PushAsync("wallpapers", @object);
            return @object;
        }
        
        public void Delete(Wallpaper @object)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Wallpaper>> GetAll()
        {
            FirebaseResponse response = await _client.GetAsync("wallpapers");
            var wallpaperDict = JsonConvert.DeserializeObject<Dictionary<string, Wallpaper>>(response.Body);

            return wallpaperDict.Values.ToList();
        }

        public Task<Wallpaper> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Wallpaper> Update(Wallpaper modifiedObject)
        {
            throw new NotImplementedException();
        }
    }
}
