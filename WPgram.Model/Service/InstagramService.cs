using WPgram.Model.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;

namespace WPgram.Model.Service
{
    public class InstagramService
    {

        public async Task<string> getClientId()
        {
            string clientId = SettingsService.GetValueOrDefault("clientId", string.Empty);
            if (clientId == string.Empty)
            {
                var installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
                StorageFile storageFile = await installedLocation.GetFileAsync("clientId.txt");
                var randomAccessStreamWithContentType = await storageFile.OpenReadAsync();
                // Open it and read the contents 
                Stream readStream = await storageFile.OpenStreamForReadAsync();
                using (StreamReader reader = new StreamReader(readStream))
                {
                    clientId = await reader.ReadToEndAsync();
                }
                if (clientId == string.Empty)
                {
                    throw new Exception("Exit");
                }
                else
                {
                    SettingsService.AddOrUpdateValue("clientId", clientId);
                    SettingsService.Save();
                }
            }
            return clientId;
        }


        public async Task<FeedClass> GetFeed()
        {
            return await InstagramCall<FeedClass>("https://api.instagram.com/v1/users/self/feed?access_token=");
        }

        private async Task<TResult> InstagramCall<TResult>(string baseUri)
        {
            var accessToken = SettingsService.GetValueOrDefault("accessToken", "");
            if (accessToken == "")
            {
                throw new EmptyAccessTokenException();
            }
            using (var stream = await OpenStream<TResult>(new Uri(baseUri + accessToken)))
            {
                var serializer = new DataContractJsonSerializer(typeof(FeedClass));
                return (TResult)serializer.ReadObject(stream);
            }
        }

        private async Task<Stream> OpenStream<TResult>(Uri uri)
        {
            var webClient = new WebClient();
            try
            {
                return await webClient.OpenReadTaskAsync(uri);
            }
            catch (WebException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
