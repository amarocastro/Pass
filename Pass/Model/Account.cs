using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pass.Model
{
    public class Account
    {
        private string name
        {
            get => this.name;
            set => this.name = value;
        }
        private string login_name
        {
            get => this.login_name;
            set => this.login_name = value;
        }
        private string email
        {
            get => this.email;
            set => this.email = value;
        }
        private string password
        {
            get => this.password;
            set => this.password = value;
        }

        private string note
        {
            get => this.note;
            set => this.note = value;
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
