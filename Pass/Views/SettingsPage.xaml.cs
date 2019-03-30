using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Pass.Model;
using Pass.Utils;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pass.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private User _activeUser;

        public SettingsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _activeUser = (User)e.Parameter;
        }

        private void Button_Restart_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Forget_User_Click(object sender, RoutedEventArgs e)
        {
            // Remove it from Microsoft Passport
            MicrosoftLoginHelper.RemovePassportAccountAsync(_activeUser);

            // Remove it from the local accounts list and resave the updated list
            UserHelper.RemoveUser(_activeUser);

            Debug.WriteLine("User " + _activeUser.Username + " deleted.");
        }
    }
}
