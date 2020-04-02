using Prism.Navigation;
using Prism.Services;
using realSafewayz.ViewModels;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace realSafewayz.Views
{
    public partial class MapPage : ContentPage
    {
        private MapPageViewModel ViewModel
        {
            get { return BindingContext as MapPageViewModel; }
            set { BindingContext = value; }
        }
        public IPageDialogService _dialogService;
        public INavigationService _navigationService;
        public MapPage(IPageDialogService dialogService, INavigationService navigationService)
        {
            InitializeComponent();
            _dialogService = dialogService;
            _navigationService = navigationService;
            BindingContext = new MapPageViewModel( dialogService, navigationService);
            MapPageViewModel.myMap = myMap;
        }

        private async void myMap_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            ViewModel.MapClickedCommand.Execute(e.Position);
        }
    }
}
