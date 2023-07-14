using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;


namespace maps
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetLocation();
        }

        private async void GetLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Default);
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                var defaultPin = new Pin
                {
                    Type = PinType.Place,
                    Label = "My Location",
                    Position = new Position(location.Latitude, location.Longitude)
                };

                map.Pins.Add(defaultPin);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(defaultPin.Position, Distance.FromKilometers(1)));
            }
        }

    }
}
