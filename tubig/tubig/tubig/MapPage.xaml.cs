﻿using System;
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
using System.Collections.ObjectModel;

using System.ComponentModel;

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
            // this.AddMarkerInCurrentLocation();

            Pin storePin = new Pin()
            {
                Type=PinType.Place,
                Label="Dici Station",
                Address="V Rama, Cebu City,Philippines",
                Position= new Position(10.29951935851668, 123.88736288926488),
                
            };
            myMap.Pins.Add(storePin);
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(storePin.Position, Distance.FromMeters(500)));

            Pin storePin1 = new Pin()
            {
                Type = PinType.Place,
                Label = "Rhea Station",
                Address = "V Rama, Cebu City,Philippines",
                Position = new Position(10.2987896, 123.8873807),

            };
            myMap.Pins.Add(storePin1);
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(storePin1.Position, Distance.FromMeters(500)));

        }

        //private async void AddMarkerInCurrentLocation()
        //{
        //    try
        //    {
        //        var location = await Geolocation.GetLastKnownLocationAsync();
        //        if (location != null)
        //        {
        //            CustomMarker marker = new CustomMarker();
        //            marker.Latitude = location.Latitude.ToString();
        //            marker.Longitude = location.Longitude.ToString();
        //            this.layer.Markers = new ObservableCollection<Syncfusion.SfMaps.XForms.MapMarker> { marker };

        //            this.layer.GeoCoordinates = new Point(location.Latitude, location.Longitude);
        //            this.layer.Radius = 700;
        //            this.layer.DistanceType = DistanceType.KiloMeter;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle not supported on device exception
        //        await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
        //    }
        //}





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
                (FeatureNotEnabledException fneEx)
            { 

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

    public class CustomMarker : Syncfusion.SfMaps.XForms.MapMarker
    {
        public ImageSource Image { get; set; }
        public CustomMarker()
        {
            Image = ImageSource.FromResource("pin.png");
        }
    }
}