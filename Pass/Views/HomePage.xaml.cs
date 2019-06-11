using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Pass.Utils;
using Pass.Model;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pass.Views
{
    public sealed partial class HomePage : Page
    {

        public AccountViewModel ViewModel { get; set; }

        public HomePage()
        {
            this.InitializeComponent();
            this.ViewModel = new AccountViewModel();
        }


        /*private async void LoadData(Object sender, RoutedEventArgs e)
        {
            //List<Account> accountList = await FileHelper.OpenData();
            if (!(accountList.Count == 0))
            {
                stuff_List.ItemsSource = accountList;
            }
        }*/

    }
}
