using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    }
}
