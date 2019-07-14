using Newtonsoft.Json;
using Pass.Model;
using Windows.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Pass.Utils
{
    public static class FileHelper
    {
        //private static string accountDataPath = "ms-appdata:///local/data.json";
        private static List<Account> accountsList = new List<Account>();
        private static String json;
        private static StorageFile storageFile;
        //private static bool dataExists = File.Exists(accountDataPath);
        
        public static async Task<List<Account>> OpenData()
        {
            storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("data.json",CreationCollisionOption.OpenIfExists);
            json = await FileIO.ReadTextAsync(storageFile);

            if (!String.IsNullOrEmpty(json))
            {
                accountsList = JsonConvert.DeserializeObject<List<Account>>(json);
            }

            return accountsList;
            /*if (!dataExists)
            {
                File.Create(accountDataPath);
                dataExists = File.Exists(accountDataPath);
            }*/

            /*if (dataExists)
            {
                try
                {
                    string accountsData = await File.ReadAllTextAsync(accountDataPath);
                    accountsList = JsonConvert.DeserializeObject<List<Account>>(accountsData);
                }
                catch(ArgumentException e)
                {
                    //The file is empty, the list will be empty
                }
            }*/

        }

        public static async Task<bool> AddItem(Account account)
        {
            accountsList.Add(account);
            json = JsonConvert.SerializeObject(accountsList);

            await FileIO.WriteTextAsync(storageFile, json);

            return true;
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
