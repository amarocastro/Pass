using System;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.Security.Credentials;
using Pass.Model;
using System.Collections.Generic;

namespace Pass.Utils
{
    public class CredentialHelper
    {
        private PasswordVault passwordVault = new PasswordVault();
        private string resourceName = "PassApp";

        public void Add_Credential(String username, String password)
        {
            var credential = new PasswordCredential(resourceName, username, password);
            passwordVault.Add(credential);
        }

        private PasswordCredential Find_credential_byUser(String username)
        {
            PasswordCredential credential = null;
            try
            {
                credential = passwordVault.Retrieve(resourceName, username);
                return credential;
            }
            catch(Exception e)
            {
                return credential;
            }            
        }

        public bool validateUser(string username, string password)
        {
            bool is_valid;
            PasswordCredential credential = Find_credential_byUser(username);
            string pass = credential.Password;

            if(password == pass)
            {
                is_valid = true;
            }
            else
            {
                is_valid = false;
            }

            return is_valid;
        }

        public Boolean Exists_Credential(String username)
        {
            PasswordCredential exists = Find_credential_byUser(username);
            if (exists == null)
            {
                return false;
            }
            else
            {
                passwordVault.Remove(exists);

                return true;
            }
        }

        public Boolean Delete_Credential(String username, String password)
        {
            Boolean exists = Exists_Credential(username);

            if (exists)
            {
                PasswordCredential credential = Find_credential_byUser(username);
                passwordVault.Remove(credential);
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
