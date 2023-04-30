using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static string[] Scopes = { DriveService.Scope.Drive };
    static string ApplicationName = "Your application name";
    static UserCredential credential;

    static void Main(string[] args)
    {
        string privateKey = System.IO.File.ReadAllText("privatekey.txt");

        // Create credentials for the application
        ServiceAccountCredential credential = new ServiceAccountCredential(
            new ServiceAccountCredential.Initializer("service-account-565@mercurial-weft-385214.iam.gserviceaccount.com")
            {
                Scopes = Scopes
            }.FromPrivateKey(privateKey)
        );

        // Create Drive API service
        var service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });


        // Upload image to Drive
        var fileMetadata = new Google.Apis.Drive.v3.Data.File()
        {
            Name = "image.png",
            MimeType = "image/png",
        };

        FilesResource.CreateMediaUpload request;
        using (var stream = new FileStream("image.png", FileMode.Open))
        {
            request = service.Files.Create(fileMetadata, stream, fileMetadata.MimeType);
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
        service.Permissions.Create(permission, file.Id).Execute();

        Console.WriteLine("File shared successfully.");
    }
}
