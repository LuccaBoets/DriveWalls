using Core.Models;
using Core.Ports.Driving.Api;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Database.Repository
{
    public class MetadataRepository : IMetadataRepository
    {
        public IFirebaseClient _client { get; set; }

        public MetadataRepository()
        {
            _client = DatabaseClient.GetClient();
        }

        public async Task<Metadata> Create(Metadata @object)
        {
            await _client.SetAsync($"metadata/{@object.Id}", @object);
            return @object;
        }
        
        public void Delete(string id)
        {
            _client.DeleteAsync($"metadata/{id}");
        }

        public async Task<List<Metadata>> GetAll()
        {
            FirebaseResponse response = await _client.GetAsync("metadata");
            Console.WriteLine(response.Body);
            var metaDict = JsonConvert.DeserializeObject<List<Metadata>>(response.Body);

            return metaDict;
        }

        public Task<Metadata> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Metadata> Update(Metadata modifiedObject)
        {
            throw new NotImplementedException();
        }
    }
}
