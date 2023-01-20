using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountSetting : ContentPage
    {
        CUSTOMER customer = new CUSTOMER();
        CustomerRepo customerRepo = new CustomerRepo();
        public AccountSetting()
        {
            InitializeComponent();
            
            labelShowname.Text= Preferences.Get("customerFullname", customer.CusFirstName  +" "+customer.CusMiddleName + " " +customer.CusLastName);

            entryfieldEmail.Text = Preferences.Get("customerEmail", "default");
          
            entryfieldFirstname.Text = Preferences.Get("customerFirstname", customer.CusFirstName);
            entryfieldMiddlename.Text= Preferences.Get("customerMiddlename", customer.CusMiddleName);
            entryfieldLastname.Text= Preferences.Get("customerLastname", customer.CusLastName);
            entryfieldNumber.Text = Preferences.Get("customerContactNumber", customer.CusContactNumber);
            entryfieldDOB.Text = Preferences.Get("customerDOB", customer.CusBirthOfDate);
            entryField_Address.Text = Preferences.Get("customerAddress", customer.CusAddress);
        }

       

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {

            string updateFirstname = entryfieldFirstname.Text;
            string updateLastname = entryfieldLastname.Text;
            string updateMiddlename = entryfieldMiddlename.Text;
            string udpateContactnumber = entryfieldNumber.Text;
            string updateDOB = entryfieldDOB.Text;
            string updateAdress = entryField_Address.Text;

            string EmailToken = Preferences.Get("token","default");
            customer.CusFirstName = updateFirstname;
            customer.CusLastName = updateLastname;
            customer.CusMiddleName = updateMiddlename;
            customer.CusContactNumber = udpateContactnumber;
            customer.CusBirthOfDate = updateDOB;
            customer.CusAddress = updateAdress;
            bool isUpdated = await customerRepo.Update(customer);

            if (isUpdated)
            {
                await DisplayAlert("Success", "You have updated your data successfully.", "OK");
               // return;
                // await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "Update failed.", "Cancel");
            }
          

        }

        private async void update_AddressImageButton_Clicked(object sender, EventArgs e)
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

              
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    

                    var geocodeAddress_Alert = "\n" +
                    locationInfo +
                   $"\n{ placemark.Thoroughfare}\n" +
                   $"{ placemark.FeatureName}\n" +
                   $"{ placemark.SubLocality}\n" + //Address area name
                   $"{placemark.Locality} " +
                   $"{placemark.SubAdminArea}\n" + //CityName- Cebu City,, SubAdminarea- Cebu
                   $"{placemark.PostalCode}\n" + //PostalCode
                   $"{placemark.AdminArea}\n" + //StateName- Central Visayas
                   $"{placemark.CountryName}\n" + //CountryName-philippines
                   $"{placemark.CountryCode}\n";// PH   locality subadmin
                    await DisplayAlert("Your Location", geocodeAddress_Alert, "Ok");

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

        private  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Preferences.Remove("token");
          
        }
    }
}