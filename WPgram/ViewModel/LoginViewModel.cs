using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPgram.Model.Service;
using System;
using System.Threading.Tasks;
using WPgram.Model.Service;

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

        private Uri currentUri = null;

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

        private RelayCommand<string> scriptNotifyCommand;
        private INavigationService NavigationService;
        private InstagramService InstagramService;

        /// <summary>
        /// Gets the ScriptNotifyCommand.
        /// </summary>
        public RelayCommand<string> ScriptNotifyCommand
        {
            get
            {
                return scriptNotifyCommand
                    ?? (scriptNotifyCommand = new RelayCommand<string>(
                                          accessToken =>
                                          {
                                              SettingsService.AddOrUpdateValue("accessToken", accessToken);
                                              SettingsService.Save();
                                              this.NavigationService.NavigateTo(new Uri("/FeedPage.xaml", UriKind.Relative));
                                          }));
            }
        }

        /// <summary>
        /// Initializes a new instance of the InstagramLoginViewModel class.
        /// </summary>
        public LoginViewModel(INavigationService navigationService, InstagramService instagramService)
        {
            this.NavigationService = navigationService;
            this.InstagramService = instagramService;
        }

        public async Task Initialize()
        {
            var clientId = await InstagramService.getClientId();
            this.currentUri = new Uri("https://instagram.com/oauth/authorize/?client_id=" + clientId + "&redirect_uri=http://hic-sunt-leones.appspot.com/instagram-login.html&response_type=token");
        }
    }
}