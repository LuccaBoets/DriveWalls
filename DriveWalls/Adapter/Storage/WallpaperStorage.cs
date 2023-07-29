using Core.Api.Service;
using Core.Models;
using Core.Ports.Driven.Storage;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class WallpaperStorage : IWallpaperStorage
    {
        private DriveService _storageService;

        public WallpaperStorage()
        {
            _storageService = StorageService.GetStorage();
        }

        public void Delete(String id)
        {
            _storageService.Files.Delete(id.ToString()).Execute();
        }

        public string Save(string uri)
        {
            // Upload image to Drive
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "image.png",
                MimeType = "image/png",
            };

            FilesResource.CreateMediaUpload request;
            Uri fileUri = new Uri(uri);
            WebRequest requestTemp = WebRequest.Create(fileUri);

            using (var response = requestTemp.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                request = _storageService.Files.Create(fileMetadata, stream, fileMetadata.MimeType);
                request.Fields = "id, webContentLink";
                request.Upload();
            }
            var file = request.ResponseBody;
            Console.WriteLine("File ID: " + file.Id);
            Console.WriteLine("File link: " + file.WebContentLink);

            var permission = new Permission()
            {
                Type = "anyone",
                Role = "reader",
            };
            _storageService.Permissions.Create(permission, file.Id).Execute();

            Console.WriteLine("File shared successfully.");

            return file.Id;
        }
    }
}
