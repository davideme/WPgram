using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace Instagram_lock_screen.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="CurrentUri" /> property's name.
        /// </summary>
        public const string CurrentUriPropertyName = "CurrentUri";

        private Uri currentUri = new Uri("https://instagram.com/oauth/authorize/?client_id=7de62820950242b891b9cb27181573b5&redirect_uri=http://hic-sunt-leones.appspot.com/instagram-login.html&response_type=token");

        /// <summary>
        /// Sets and gets the CurrentUri property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Uri CurrentUri
        {
            get
            {
                return currentUri;
            }

            set
            {
                if (currentUri == value)
                {
                    return;
                }

                RaisePropertyChanging(CurrentUriPropertyName);
                currentUri = value;
                RaisePropertyChanged(CurrentUriPropertyName);
            }
        }

        //private RelayCommand<string> scriptNotifyCommand;
        //private INavigationService NavigationService;

        ///// <summary>
        ///// Gets the ScriptNotifyCommand.
        ///// </summary>
        //public RelayCommand<string> ScriptNotifyCommand
        //{
        //    get
        //    {
        //        return scriptNotifyCommand
        //            ?? (scriptNotifyCommand = new RelayCommand<string>(
        //                                  accessToken =>
        //                                  {
        //                                      SettingsService.AddOrUpdateValue("accessToken", accessToken);
        //                                      SettingsService.Save();
        //                                      (Application.Current as App).JustLoggedIn = true;
        //                                      this.NavigationService.NavigateTo(new Uri("/SettingsPage.xaml", UriKind.Relative));
        //                                  }));
        //    }
        //}

        ///// <summary>
        ///// Initializes a new instance of the InstagramLoginViewModel class.
        ///// </summary>
        //public InstagramLoginViewModel(INavigationService navigationService)
        //{
        //    this.NavigationService = navigationService;
        //}
    }
}