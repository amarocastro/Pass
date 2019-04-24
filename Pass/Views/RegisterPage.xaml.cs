using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Pass.Utils;
using Pass.Model;
using Windows.UI.Xaml.Media;
using System.Drawing;


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

        private void RegisterButton_Click_Async(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = "";
           
            string username = UsernameTextBox.Text;
            string password1 = PasswordTextBox1.Password;
            string password2 = PasswordTextBox2.Password;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password1) && !string.IsNullOrEmpty(password2))
            {
                if (User_exists(username))
                {
                    ErrorMessage.Text = "The username is taken";
                }
                else if (password1.Equals(password2))
                {
                    credentialManager.Add_Credential(username, password1);
                    Frame.Navigate(typeof(LoginPage));
                }
                else
                {
                    ErrorMessage.Text = "The passwords are different";
                }
            }
            
            else
            {
                ErrorMessage.Text = "Please complete all fields";
            }
        }

        private bool User_exists(string username)
        {
            return credentialManager.Exists_Credential(username);
        }
    }
}
