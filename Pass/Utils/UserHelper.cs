using System;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Windows.Storage;
using Pass.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pass.Utils
{
    public static class UserHelper
    {
        private const string USER_ACCOUNT_LIST_NAME = "useroinfo.txt";
        private static string _accountListPath = Path.Combine(
                    ApplicationData.Current.LocalFolder.Path, USER_ACCOUNT_LIST_NAME);
        public static List<User> UserList = new List<User>();

        public static async void SaveUserListAsync()
        {
            string accountsXml = SerializeUserListToXml();

            if (File.Exists(_accountListPath))
            {
                StorageFile accountsFile = await StorageFile.GetFileFromPathAsync(_accountListPath);
                await FileIO.WriteTextAsync(accountsFile, accountsXml);
            }
            else
            {
                StorageFile accountsFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(USER_ACCOUNT_LIST_NAME);
                await FileIO.WriteTextAsync(accountsFile, accountsXml);
            }
        }

        public static async Task<List<User>> LoadUserListAsync()
        {
            if (File.Exists(_accountListPath))
            {
                StorageFile accountsFile = await StorageFile.GetFileFromPathAsync(_accountListPath);

                string accountsXml = await FileIO.ReadTextAsync(accountsFile);
                DeserializeXmlToUserList(accountsXml);
            }

            return UserList;
        }

        public static string SerializeUserListToXml()
        {
            XmlSerializer xmlizer = new XmlSerializer(typeof(List<User>));
            StringWriter writer = new StringWriter();
            xmlizer.Serialize(writer, UserList);

            return writer.ToString();
        }

        public static List<User> DeserializeXmlToUserList(string listAsXml)
        {
            XmlSerializer xmlizer = new XmlSerializer(typeof(List<User>));
            TextReader textreader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(listAsXml)));

            return UserList = (xmlizer.Deserialize(textreader)) as List<User>;
        }

        public static User AddUser(string username)
        {
            User user = new User { Username = username };
            UserList.Add(user);
            SaveUserListAsync();
            return user;
        }

        public static void RemoveUser(User user)
        {
            UserList.Remove(user);
            SaveUserListAsync();
        }

        public static bool ValidateUserCredentials(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            if (!string.Equals(username, "sample"))
            {
                return false;
            }

            return true;
        }
    }   
        
}
