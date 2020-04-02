using realSafewayz.Models;
using realSafewayz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace realSafewayz.Services
{
    public class MapServices
    { 
        public static Map myMap;
        public async Task<Position> GetPosition(string address)
        {
            Geocoder geoCoder = new Geocoder();
            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);

            Position pos = new Position();
            pos = approximateLocations.FirstOrDefault();

            return pos;
        }


        public async void PlotPositions(List<Position> _positions, IList<Pin> _pins, ObservableCollection<IncidentReport> _reports)
        {
           //// _positions = new List<Position>();
           // _pins = new List<Pin>();

            for (int i = 0; i <= _reports.Count - 1; i++)
            {
                Position pos = new Position();
                pos = await GetPosition(_reports[i].Area);

                Pin pin = new Pin
                {
                    Label = _reports[i].Incident,
                    Address = _reports[i].IncidentDescription,
                    Type = PinType.Generic,
                    Position = pos
                };
                myMap.Pins.Add(pin);
                _pins.Add(pin);
                _positions.Add(pos);
            }
        }

        public Task<int> SaveIncidentReportAsync(IncidentReport newReport)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveItemAsync(UserProfile info)
        {
            throw new NotImplementedException();
        }
    }
}
