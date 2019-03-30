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
        private User _user;
        
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ErrorMessage.Text = "";
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // Check Microsoft Passport is setup and available on this machine
            if (await MicrosoftLoginHelper.MicrosoftLoginAvailableCheckAsync())
            {
            }
            else
            {
                // Microsoft Passport is not setup so inform the user
                /*PassportStatus.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 170, 207));
                PassportStatusText.Text = "Microsoft Passport is not setup!\n" +
                    "Please go to Windows Settings and set up a PIN to use it.";*/
                PassSignInButton.IsEnabled = false;
            }
        }

        private void PassSignInButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = "";
            SignInPass();
        }

        private async void SignInPass()
        {
            if (UserHelper.ValidateUserCredentials(PasswordTextBox.Text))
            {
                // Create and add a new local account
                _user = UserHelper.AddUser(PasswordTextBox.Text);
                Debug.WriteLine("Successfully signed in with traditional credentials and created local account instance!");

                if (await MicrosoftLoginHelper.CreatePassKeyAsync(PasswordTextBox.Text))
                {
                   Debug.WriteLine("Successfully signed in with Microsoft Passport!");
                   Frame.Navigate(typeof(MainPage), _user);
                }
            }
            else
            {
                ErrorMessage.Text = "Invalid Credentials";
            }
        }
    }
}
