using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WPgram.Resources;
using Instagram_lock_screen.ViewModel;

namespace WPgram
{
    public partial class LoginPage : PhoneApplicationPage
    {
        // Constructor
        public LoginPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected override async void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemTray.ProgressIndicator.IsVisible = true;
            await (this.DataContext as LoginViewModel).Initialize();
            SystemTray.ProgressIndicator.IsVisible = false;
        }

        private void WebBrowser_Navigating_1(object sender, NavigatingEventArgs e)
        {
            SystemTray.ProgressIndicator.IsVisible = true;
        }

        private void WebBrowser_LoadCompleted_1(object sender, NavigationEventArgs e)
        {
            if (SystemTray.ProgressIndicator != null)
            {
                SystemTray.ProgressIndicator.IsVisible = false;
            }
        }

        private void WebBrowser_ScriptNotify_1(object sender, NotifyEventArgs e)
        {
            (this.DataContext as LoginViewModel).ScriptNotifyCommand.Execute(e.Value);
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}