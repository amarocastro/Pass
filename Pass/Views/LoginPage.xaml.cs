using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Pass.Utils;
using Pass.Model;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pass.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
             
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void PassSignInButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = "";
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            bool succesfull = SignInPass(username,password);

            if(succesfull == true)
            {
                Frame.Navigate(typeof(MainPage), username);
            }
            else
            {
                ErrorMessage.Text = "Wrong credentials";
            }
        }

        private bool SignInPass(string username, string password)
        {
            CredentialHelper credentialManager = new CredentialHelper();
            bool is_valid = credentialManager.validateUser(username,password);


            return is_valid;
        }

        private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ErrorMessage.Text = "";
            Frame.Navigate(typeof(RegisterPage));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
