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
       // StationInfo myvalue = new StationInfo();
        public MapPage()
        {
            InitializeComponent();
            //location();
            //  pinloc();
            // getlocation();
            DisplayCurrentLocation();
            //  Map.OpenAsync(10.367180176504233, 123.91768852643828);
            //Position position = new Position(36.9628066, -122.0194722);
            // MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            //Map map = new Map(mapSpan);
            //  Map map = new Map(mapSpan);   10.36741934533169, 123.91710302006388
            // DisplayCurrentLocation();

        }

        public async void getlocation()
        {
            Location location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium
                });
            }
            // System.Diagnostics.Debug.WriteLine($"MapClick: {Position.Latitude}, {Position.Longitude}");
          
        }

        public void pinloc()
        {
            Pin pintalamban = new Pin()
            {
                Type = PinType.Place,
                Label = "Talamban",
                Address = "Talamban, Cebu City",
                Position = new Position(10.367032849285907, 123.91804016846208),
                //10.366520235711947, 123.91815160087579    10.3671 , 123.9174
                //10.367180176504233, 123.91768852643828


            };
            map.Pins.Add(pintalamban);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pintalamban.Position, Distance.FromMeters(500)));
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
                 //  Position p = new Position(10.367032849285907, 123.91804016846208);

                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromKilometers(.444));
                    map.MoveToRegion(mapSpan);
                  //  Console.WriteLine($"Latitude: { location.Latitude},Longitude: { location.Longitude},Altitude: { location:altitude}");
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

    
        public void ApplyMapTheme()
        {
            var assembly = typeof(MapPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"tubig.MapResources.MapTheme.json");
            string themeFile;

            using (var reader = new System.IO.StreamReader(stream))
            {
                themeFile = reader.ReadToEnd();
              //  map
            }
        }

        private void map_MapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }
    }
}