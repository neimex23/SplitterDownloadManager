using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
namespace SplitterDownloadManager
{
    public class DriveModule
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "SplitterDownloadManager";
        
        public DriveService GetService()
        {
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetCredetials(),
                ApplicationName = ApplicationName
            });

            return service;
        }
        private static UserCredential GetCredetials()
        {
            UserCredential credential;
            using (var Stream = new FileStream("DriveCredential.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(Stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            return credential;
        }
    }
}
