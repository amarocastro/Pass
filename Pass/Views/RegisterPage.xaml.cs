using System;
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
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        CredentialHelper credentialManager = new CredentialHelper();

        private async void RegisterButton_Click_Async(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = "";
            string username;
            string password;
             
            

            if (!string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                //Register a new account
                username = UsernameTextBox.Text;
                password = PasswordTextBox.Text;
                //Register new account with Microsoft Passport
                credentialManager.Add_Credential(username, password);
                //Navigate to the Welcome Screen. 
                Frame.Navigate(typeof(LoginPage));
            }
            else
            {
                ErrorMessage.Text = "Please enter a username";
            }
        }
    }
}
