
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RuntestforPopUp : ContentPage
    {
        private OrderProductReviewPagePopUp _loginPopup;
        CancellationTokenSource cts;
        public RuntestforPopUp()
        {
            InitializeComponent();
            PopupNavigation.Instance.Pushing += (sender, e) => Debug.WriteLine($"[Popup] Pushing: {e.Page.GetType().Name}");
            PopupNavigation.Instance.Pushed += (sender, e) => Debug.WriteLine($"[Popup] Pushed: {e.Page.GetType().Name}");
            PopupNavigation.Instance.Popping += (sender, e) => Debug.WriteLine($"[Popup] Popping: {e.Page.GetType().Name}");
            PopupNavigation.Instance.Popped += (sender, e) => Debug.WriteLine($"[Popup] Popped: {e.Page.GetType().Name}");

            _loginPopup = new OrderProductReviewPagePopUp();

            //GetAddressCommand = new Command(async () => await OnGetAddress())
            //     GetAddresscCommand = new Command(async () => await OnGetPosition());
        }

        string geoCodeAddress;
        string geoCodePosition;
        public double lat { get; set; }
        public double longtd { get; set; }


        private async void OnOpenPupup(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(_loginPopup);
        }

        async private void btnGetCurrentLocation_Clicked(object sender, EventArgs e)
        {
            btnEnabler(false);
            try
            {
                var request = new Xamarin.Essentials.GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(20));
                CancellationTokenSource cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                    await GetLocation(location);
                else
                    await DisplayAlert("Unknown", "Your Location is unknown", "Ok");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error occurred", ex.Message.ToString(), "Ok");
            }
            btnEnabler(true);

        }

        public async Task GetLocation(Location location)
        {
            //  var positions = await _geocoder.GetPositionsForAddressAsync("Cebu,Labangon,Philippines");
            //  await DisplayAlert("Position", $"Lat:{positions.First().Latitude},Long:{positions.First().Longitude}", "Ok");
            try
            {
                var locationInfo = $"Latitude: {location.Latitude}\n" +
                $"Longitude: {location.Longitude}\n";

                 //lblLocationInfo.Text = locationInfo;

              //  lblLocationInfo.Text = locationInfo;
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    var geocodeAddress = "\n" +
                        $"{ placemark.Thoroughfare}\n" + //Address //Salvador Street
                        $"{ placemark.SubLocality}\n" + //Address area name
                        $"{placemark.Locality} " +
                        $"{placemark.SubAdminArea}\n" + //CityName- Cebu City,, SubAdminarea- Cebu
                        $"{placemark.PostalCode}\n" + //PostalCode
                        $"{placemark.AdminArea}\n" + //StateName- Central Visayas
                        $"{placemark.CountryName}\n" + //CountryName-philippines
                        $"CountryCode: {placemark.CountryCode}\n";// PH
                                                                  //  var geocodeAddress = $"{ placemark.Thoroughfare}" + $" {placemark.Locality}";


                    //  lblLocationInfo.Text += geocodeAddress;
                    lbl_LongLat.Text += geocodeAddress;
                }
                else
                    await DisplayAlert("Error occurred", "Unable to retreive address information", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error occurred", ex.Message.ToString(), "Ok");
            }
        }

        public void btnEnabler(bool val)
        {
            // btnGetCurrentLocation.IsEnabled = val;
            // btnGetLastKnownLocation.IsEnabled = val;
            // Map map
            //Map map = new Xamarin.Essentials.Map();
            //DisplayAlert("Buang ka?", "amaw naka oy", "Ok");
            //   await NavigationPage = new NavigationPage(MapPage());
        }



        async public void ImageButton_Clicked_GetPlacemark(object sender, EventArgs e)
        {
            btnEnabler(false);
            try
            {
                var request = new Xamarin.Essentials.GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(20));
                CancellationTokenSource cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                    await GetLocationNew(location);
                else
                    await DisplayAlert("Unknown", "Your Location is unknown", "Ok");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error occurred", ex.Message.ToString(), "Ok");
            }
            btnEnabler(true);

        }

        public async Task GetLocationNew(Location location)
        {
            try
            {
                var locationInfo = $"Latitude: {location.Latitude}\n" +
                $"Longitude: {location.Longitude}\n";

                // lblLocationInfo.Text = locationInfo;
                lbl_LongLat.Text = locationInfo;
                //  lblLocationInfo.Text = locationInfo;
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    //var geocodeAddress = "\n" +
                    //Address //Salvador Street   $"{ placemark.Thoroughfare}\n" + 
                    // $"{ placemark.FeatureName}\n" +
                    //$"{ placemark.SubLocality}\n" + //Address area name
                    //$"{placemark.Locality} " +
                    //$"{placemark.SubAdminArea}\n" + //CityName- Cebu City,, SubAdminarea- Cebu
                    //$"{placemark.PostalCode}\n" + //PostalCode
                    //$"{placemark.AdminArea}\n" + //StateName- Central Visayas
                    //$"{placemark.CountryName}\n" + //CountryName-philippines
                    //$"CountryCode: {placemark.CountryCode}\n";// PH   locality subadmin

                    var geocodeAddress =
                       $"{placemark.FeatureName}"
                       + $" {placemark.Thoroughfare }"
                      + $" {placemark.Locality}"
                       +$" {placemark.SubAdminArea}";

                    entryAddress.Text += geocodeAddress;
                    lbl_LongLat.Text += geocodeAddress;
                }
                else
                    await DisplayAlert("Error occurred", "Unable to retreive address information", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error occurred", ex.Message.ToString(), "Ok");
            }

        }
        async public void ImageButton_Clicked(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new CreateAcc_AddressMap());

            //get the latlong

            /* try
{
    var location = await Geolocation.GetLastKnownLocationAsync();

    if (location != null)
    {
        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
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
}*/
            try
            {
                //var location = await Geolocation.GetLastKnownLocationAsync();

                //if (location == null)
                //{
                //    location = await Geolocation.GetLocationAsync(new Xamarin.Essentials.GeolocationRequest
                //    {
                //        DesiredAccuracy=GeolocationAccuracy.Medium,
                //        Timeout=TimeSpan.FromSeconds(30)
                //    });



                //}
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);


                if (location != null)
                {
                   
                    //lbl_LongLat.Text = ($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                //if (location == null)
                //{
                //    lbl_LongLat.Text = "NO GPS ";
                //}
                //else
                //{
                //    lbl_LongLat.Text = $"{location.Latitude}/n{location.Longitude}";
                //}

            }
            catch (Exception ex)
            {
                // Debug.Writeline($""Something is Wrong:{ex.Message}");
                Debug.WriteLine($"Something is wrong:{ex.Message}");
            }
        }
        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }

        async private void btn_GetPlacemark_Clicked(object sender, EventArgs e)
        {
            
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);
            var placemarks = await Geocoding.GetPlacemarksAsync(lat, longtd);
            var placemark = placemarks?.FirstOrDefault();
        }
    }
}