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
        private PasswordVault passwordVault { get; set; }
        private string resourceName = "PassApp";

        public void Add_Credential(String username, String password)
        {
            var credential = new PasswordCredential(resourceName, username, password);
            passwordVault.Add(credential);
        }

        public IReadOnlyList<PasswordCredential> find_credential_byUser(User user)
        {
           IReadOnlyList<PasswordCredential> credential_list = passwordVault.FindAllByUserName(user.Username);

            return credential_list;
        }

        public void 

    }
}
