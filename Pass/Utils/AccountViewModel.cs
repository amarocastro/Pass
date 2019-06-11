using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Pass.Model;
using Pass.Utils;

namespace Pass.Utils
{
    public class AccountViewModel
    {
        private List<Account> accountsList;

        private ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        public ObservableCollection<Account> Accounts
        {
            get
            {
                return this.accounts;
            }
        }

        public void AddtoCollection(Account account)
        {
            this.accounts.Add(account);
        }

        public async void LoadData()
        {
            this.accountsList = await FileHelper.OpenData();
        }

        public AccountViewModel()
        {
            LoadData();
        }
    }
}
