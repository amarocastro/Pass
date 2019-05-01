using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Pass.Utils
{
    

    public class FileHelper
    {
        private StorageFolder localFolder;
        private StorageFile localFile;

        public async void OpenData()
        {
            localFolder = ApplicationData.Current.LocalFolder;
            localFile = await localFolder.GetFileAsync("data.json");
        }

        public async void SaveData()
        {
            
        }

        public async void AddItem()
        {

        }
    }
}
