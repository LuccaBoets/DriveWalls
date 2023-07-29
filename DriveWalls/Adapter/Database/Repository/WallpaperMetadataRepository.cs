using Core.Models;
using Core.Ports.Driving.Api;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Database.Repository
{
    public class WallpaperMetadataRepository : IWallpaperRepository
    {
        public IFirebaseClient _client { get; set; }

        public WallpaperMetadataRepository()
        {
            _client = DatabaseClient.GetClient();
        }

        public async Task<Wallpaper> Create(Wallpaper @object)
        {
            await _client.SetAsync($"wallpapers/{@object.Id}", @object);
            return @object;
        }
        
        public void Delete(string id)
        {
            _client.DeleteAsync($"wallpapers/{id}");
        }

        public async Task<List<Wallpaper>> GetAll()
        {
            FirebaseResponse response = await _client.GetAsync("wallpapers");
            var wallpaperDict = JsonConvert.DeserializeObject<Dictionary<string, Wallpaper>>(response.Body);

            return wallpaperDict.Values.ToList();
        }

        public Task<Wallpaper> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Wallpaper> Update(Wallpaper modifiedObject)
        {
            throw new NotImplementedException();
        }
    }
}
