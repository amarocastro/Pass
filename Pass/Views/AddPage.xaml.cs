using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Pass.Model;
using Pass.Utils;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pass.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AddPage : Page
    {
        
        public AddPage()
        {
            this.InitializeComponent();
        }

        private async void AddAccount(object sender, RoutedEventArgs e)
        {
            //fileHelper.OpenData();

            string site_name = SiteName.Text;
            string account_name = AccountName.Text;
            string email = Email.Text;
            string password = Password.Text;
            string description = Description.Text;

            Account newAccount = new Account(site_name, account_name, email, password, description);

            bool confirmation = await FileHelper.AddItem(newAccount);
            //Frame.Navigate(typeof(HomePage));
        }

    }
}
