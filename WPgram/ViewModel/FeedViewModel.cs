using GalaSoft.MvvmLight;
using IWPgram.Model.Entity;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WPgram.Model.Service;

namespace WPgram.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class FeedViewModel : ViewModelBase
    {
        private INavigationService NavigationService;
        private InstagramService InstagramService;
        /// <summary>
        /// The <see cref="Feed" /> property's name.
        /// </summary>
        public const string FeedPropertyName = "Feed";

        private ObservableCollection<FeedDataClass> _feed = null;

        /// <summary>
        /// Sets and gets the Feed property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<FeedDataClass> Feed
        {
            get
            {
                return _feed;
            }

            set
            {
                if (_feed == value)
                {
                    return;
                }

                RaisePropertyChanging(FeedPropertyName);
                _feed = value;
                RaisePropertyChanged(FeedPropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the InstagramLoginViewModel class.
        /// </summary>
        public FeedViewModel(INavigationService navigationService, InstagramService instagramService)
        {
            this.NavigationService = navigationService;
            this.InstagramService = instagramService;
        }

        public async Task Initialize()
        {
            //Download the feed
            var feedClass = await InstagramService.GetFeed();
            this.Feed = new ObservableCollection<FeedDataClass>(feedClass.data);
        }
    }
}