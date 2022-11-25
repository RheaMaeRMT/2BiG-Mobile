using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using Xamarin.Forms.Maps;


namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAcc : ContentPage
    {
        public CreateAcc()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title ="Upload a clear copy of your valid ID"
            });

            var stream = await result.OpenReadAsync();

            //Imgresult.Source = ImageSource.FromStream(() =>stream);
        }

       async private void ImageButton_ClickedAddress(object sender, EventArgs e)
        {
           
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
           

        }

        public async Task GetLocationNew(Location location)
        {
            try
            {
                var locationInfo = $"Latitude: {location.Latitude}\n" +
                $"Longitude: {location.Longitude}\n";

                // lblLocationInfo.Text = locationInfo;
                //lbl_LongLat.Text = locationInfo;
                //  lblLocationInfo.Text = locationInfo;
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    //var geocodeAddress = "\n" +
                    //    $"{ placemark.Thoroughfare}\n" + //Address //Salvador Street
                    //    $"{ placemark.SubLocality}\n" + //Address area name
                    //    $"{placemark.Locality} " +
                    //    $"{placemark.SubAdminArea}\n" + //CityName- Cebu City,, SubAdminarea- Cebu
                    //    $"{placemark.PostalCode}\n" + //PostalCode
                    //    $"{placemark.AdminArea}\n" + //StateName- Central Visayas
                    //    $"{placemark.CountryName}\n" + //CountryName-philippines
                    //    $"CountryCode: {placemark.CountryCode}\n";// PH


                    /*    var geocodeAddress =
                       $"{placemark.FeatureName}"
                       + $" {placemark.Thoroughfare }"
                      + $" {placemark.Locality}"
                       +$" {placemark.SubAdminArea}";
*/
                    var geocodeAddress =
                         $"{placemark.FeatureName}"
                       + $" {placemark.Thoroughfare }"
                       + $" {placemark.Locality}"
                       + $" {placemark.SubAdminArea}";
                    // entryAddress.Text += geocodeAddress;
                    entryField_Address.Text += geocodeAddress;
                }
                else
                    await DisplayAlert("Error occurred", "Unable to retreive address information", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error occurred", ex.Message.ToString(), "Ok");
            }

        }

      
    }
}