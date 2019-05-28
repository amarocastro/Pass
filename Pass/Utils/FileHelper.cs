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
    public static class FileHelper
    {
        private static string jsonAccountData;
        private static List<Account> listAccountData;
        private static StorageFolder localFolder;
        private static StorageFile localFile;

        public static List<Account> OpenData()
        {
            OpenFiles();
            ReadFile();
            
            var list = DeserializeJson(jsonAccountData);

            listAccountData = list;

            return listAccountData;
        }

        private static async void OpenFiles()
        {
            localFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("LocalData",CreationCollisionOption.OpenIfExists);
       
            localFile = await localFolder.CreateFileAsync("data.json", CreationCollisionOption.OpenIfExists);
        }

        private static async void ReadFile()
        {
            jsonAccountData = await FileIO.ReadTextAsync(localFile);
        }

        private static List<Account> DeserializeJson(string json)
        {
            List<Account> list = JsonConvert.DeserializeObject<List<Account>>(json);

            return list;
        }

        /*private void UpdateJsonReaderWriter()
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
        }*/
    }
}
