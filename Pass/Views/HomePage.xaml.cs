using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Pass.Utils;
using Pass.Model;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pass.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private async void LoadData(Object sender, RoutedEventArgs e)
        {
            List<Account> accountList = await FileHelper.OpenData();
            if (!(accountList.Count == 0))
            {
                stuff_List.ItemsSource = accountList;
            }
        }

    }
}
