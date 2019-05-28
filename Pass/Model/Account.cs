using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Pass.Model
{
    [DataContract]
    public class Account
    {
        [DataMember]
        private string name
        {
            get; set;
        }
        [DataMember]
        private string login_name
        {
            get; set;
        }
        [DataMember]
        private string email
        {
            get; set;
        }
        [DataMember]
        private string password
        {
            get; set;
        }
        [DataMember]
        private string note
        {
            get; set;
        }

        public Account(string name, string login_name, string email, string pass, string note)
        {
            this.name = name;
            this.login_name = login_name;
            this.email = email;
            this.password = pass;
            this.note = note;           
        }

    }
}
