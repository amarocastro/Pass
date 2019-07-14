using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Pass.Views;
using Pass.Utils;
using Pass.Model;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Pass
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Iniciar en la página Home
            DbHelper.InitializeDB();

            Loaded += (sender, args) =>
            {
                NavView.SelectedItem = HomePage;
            };
        }
        public Frame AppFrame => this.ContentFrame;
        private string _activeUser; //elemento del menu seleccionado

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _activeUser = (String)e.Parameter;
        }

        private void NavViewItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var label = args.InvokedItem as string;
            var pageType =
                label == "Home" ? typeof(HomePage) :
                label == "Add" ? typeof(AddPage) : null;

            if (args.IsSettingsInvoked)
            {
                AppFrame.Navigate(typeof(SettingsPage), _activeUser);
            }
            else if (pageType != null && pageType != AppFrame.CurrentSourcePageType)
            {
                AppFrame.Navigate(pageType);
            }
        }

        /*private void NavViewBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
            }
        }*/

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
    }
}
