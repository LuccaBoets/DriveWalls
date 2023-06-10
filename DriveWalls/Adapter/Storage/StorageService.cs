using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Storage
{
    public static class StorageService
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Your application name";
        
        public static DriveService GetStorage()
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

            return service;
        }
    }
}
