
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;

namespace DAL
{
    public class GoogleDriveAPI
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        public string[] Scopes = { DriveService.Scope.DriveReadonly };
        public string ApplicationName = "Drive API .NET Quickstart";
        UserCredential credential;
        public string FolderPath;
        public GoogleDriveAPI()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string ParentFolder = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            FolderPath = System.IO.Path.Combine(ParentFolder, "DAL2\\GoogleDriveFiles");


            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
        }

        public string GetStoringFolderPath()
        {
            return FolderPath;
        }
        public List<string> DownloadFiles()
        {

            List<string> StringsFromQRCodes = new List<string>();

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();

            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.

            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                FilesResource.GetRequest request;
                foreach (var file in files)
                {
                    //Console.WriteLine("{0} ({1})", file.Name, file.Id);
                    request = service.Files.Get(file.Id);
                    //string workingDirectory = Environment.CurrentDirectory;
                    //string FolderPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

                    string FileName = request.Execute().Name;
                    string FilePath = System.IO.Path.Combine(FolderPath, FileName);

                    MemoryStream stream1 = new MemoryStream();

                    // Add a handler which will be notified on progress changes.
                    // It will notify on each chunk download and when the
                    // download is completed or failed.
                    request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    //Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    //Console.WriteLine("Download complete.");
                                    SaveStream(stream1, FilePath);
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    //Console.WriteLine("Download failed.");
                                    break;
                                }
                        }
                    };
                    request.Download(stream1);

                    //TODO: to move this section to another class in order to go along with OCP/SRP 
                    if (file.Name.StartsWith("qrcode"))
                    {
                        MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
                        string text = decoder.Decode(new QRCodeBitmapImage((Bitmap)Image.FromStream(stream1)));
                        StringsFromQRCodes.Add(text);
                    }
                }
            }
            else
            {
                //Console.WriteLine("No files found.");
            }
            //Console.Read();
            return StringsFromQRCodes;

        }

        // file save to server path
        private static void SaveStream(MemoryStream stream, string FilePath)
        {
            using (System.IO.FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }
    }
}

