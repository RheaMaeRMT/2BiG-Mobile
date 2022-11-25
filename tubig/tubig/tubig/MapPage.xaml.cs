using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using System.Reflection;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using Map = Xamarin.Essentials.Map;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage

    {
        private readonly Geocoder _geocoder = new Geocoder();
       // StationInfo myvalue = new StationInfo();
         public  MapPage()
        {
            InitializeComponent();
            DisplayCurrentLocation();
          
        }

      

       

       

        public async void DisplayCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                    
                {
                    Position p = new Position(location.Latitude, location.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(.444));
                    myMap.MoveToRegion(mapSpan);
               
                }                      
            
            }
            catch(FeatureNotSupportedException fnsEx)
            {

            }
            catch   
                (FeatureNotEnabledException fneEx){

            }
            catch(Exception ex)
            {

            }
           
        }

   
        async private void map_MapClicked_1(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
             
            await DisplayAlert("Coordinates", $"Lat:{e.Position.Latitude},Long:{e.Position.Longitude}", "Ok");
                
            var address = await _geocoder.GetAddressesForPositionAsync(e.Position);
           // myMap.MoveToRegion(MapSpan.FromCenterAndRadius(address.First(), Distance.FromMeters(500)));
            await DisplayAlert("Address", address.FirstOrDefault()?.ToString(), "OK");

            var positions = await _geocoder.GetPositionsForAddressAsync("Cebu,Labangon,Philippines");
            await DisplayAlert("Position", $"Lat:{positions.First().Latitude},Long:{positions.First().Longitude}", "Ok");

           // myMap.MoveToRegion(MapSpan.FromCenterAndRadius(address.First(), Distance.FromKilometers(1)));


            // await DisplayAlert("Coordinates", $"Lat:{e.Position.Latitude},Long:{e.Position.Longitude}", "Ok");
        }
    }
}