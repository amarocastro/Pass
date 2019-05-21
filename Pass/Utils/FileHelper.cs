using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Pass.Model;
using Newtonsoft.Json;
using System.IO;

namespace Pass.Utils
{
    

    public class FileHelper
    {
        private StorageFolder localFolder;
        private StorageFile localFile;
        private string accountsData;
        private JsonTextReader jsonReader;
        private JsonTextWriter jsonWriter;
        private List<Account> accountsList;

        public async void OpenData()
        {
            localFolder = await Package.Current.InstalledLocation.CreateFolderAsync("LocalData", CreationCollisionOption.OpenIfExists);
            localFile = await localFolder.CreateFileAsync("data.json", CreationCollisionOption.OpenIfExists);
            GetData();
            UpdateJsonReaderWriter();
        }

        private async void GetData()
        {
            string JsonText = await FileIO.ReadTextAsync(this.localFile);

            this.accountsData = JsonText;
            this.accountsList = JsonConvert.DeserializeObject<List<Account>>(JsonText);

        }

        private void UpdateJsonReaderWriter()
        {
            this.jsonReader = new JsonTextReader(new StringReader(this.accountsData));
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            this.jsonWriter = new JsonTextWriter(sw);
        }


        private async void SaveData()
        {
            this.accountsData = JsonConvert.SerializeObject(this.accountsList, Formatting.Indented);
            await FileIO.WriteTextAsync(this.localFile, this.accountsData);

        }

        public void AddItem(Account element)
        {
            //string jsonElement;

            //jsonElement = JsonConvert.SerializeObject(element);
            this.accountsList.Add(element);
            SaveData();
        }
    }
}
