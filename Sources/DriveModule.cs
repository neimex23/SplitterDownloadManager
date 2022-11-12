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
        /*const string Client_ID = "423114609853-gcm77p84uimrbsahrnk980mnb1ms9khc.apps.googleusercontent.com";
        const string Secret_ID = "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";
        const string Redirect_URI = "https://developers.google.com/oauthplayground";
        const string RefreshToken = "1//04en-9v4JoY6bCgYIARAAGAQSNwF-L9Irb1iE0QHN-abj899rNIsV9k5dpR97NvB_PtYqtvxTH7duetPn-2mt3JvqaF2WVqMNAUY";*/

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
