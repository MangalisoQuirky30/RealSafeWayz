using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using realSafewayz.Models;
using realSafewayz.Services;
using realSafewayz.Services.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Map = Xamarin.Forms.Maps.Map;

namespace realSafewayz.ViewModels
{
    public class MapPageViewModel : BindableBase , IDatabase
    {
        public IDatabase _database;
        public IPageDialogService _dialogService;
        public INavigationService _navigationService;
        public ICommand MapClickedCommand { get; private set; }
        public ObservableCollection<IncidentReport> _reports { get; set; }
        public List<Position> _positions;
        public List<Pin> _pins;
        public static Map myMap;
        public MapServices _mapServices;


        public MapPageViewModel(IPageDialogService dialogService, INavigationService navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            MapClickedCommand = new Command<Position>(async pos => await ClickMap(pos));
        }

        private async Task ClickMap(Position position)
        {
            var pos = position;
            var placemarks = await Geocoding.GetPlacemarksAsync(pos.Latitude, pos.Longitude);
            var placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
                string geocodeAddress = placemark.AdminArea;

                var response = await _dialogService.DisplayAlertAsync("Location", geocodeAddress, "New Report", "Cancel");
                if (response)
                {
                    // navigate to new post page with address on the address entry
                    var p = new NavigationParameters();
                    p.Add("Address", "geocodeAddress");
                    await _navigationService.NavigateAsync("IncidentReportPage", p);
                }

            }
        }
        protected async virtual void OnAppearing()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    var currentPosition = new Position(location.Latitude, location.Longitude);
                    myMap.MoveToRegion(MapSpan.FromCenterAndRadius(currentPosition, Distance.FromMiles(30)));

                    //  get all reports and populate in ObservableCollection
                    var allReports = await _database.GetAllIncidentReportInformationData();

                    foreach (var report in allReports)
                    {
                        _reports.Add(report);
                    }

                    //  Plot positions of incidents on map
                    _mapServices.PlotPositions(_positions, _pins, _reports);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            //var location = await locator.GetPositionAsync(TimeSpan.FromTicks(10000));
            //Position position = new Position(location.Latitude, location.Longitude);

            // USE THIS CODE    myMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(3)));
            //var map = new Map(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(10)));
            //var mapSpan = new MapSpan();
           
        }

        public Task<int> SaveItemAsync(UserProfile info)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProfile>> GetAllInformationData()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> GetPeopleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IncidentReport>> GetAllIncidentReportInformationData()
        {
            throw new NotImplementedException();
        }

        public Task<IncidentReport> GetIncidentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllIncidentReportInformation()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveIncidentReportAsync(IncidentReport newReport)
        {
            throw new NotImplementedException();
        }
    }
}
