﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using Xamarin.Forms.Maps;
using Firebase.Database;
using tubig.DataModel;
using Firebase.Database.Query;
using Xamarin.CommunityToolkit.Extensions;
using tubig.Interface;
using Newtonsoft.Json;
using tubig.firebasehelper;
using Plugin.Media;
using Firebase.Storage;
using System.Diagnostics;
using System.IO;
using tubig.FIREBASETHING;
using tubig.Model;
using tubig.Control;
namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAcc : ContentPage
    {
        FirebaseClient firebaseClient;
        CustomerRepo customerRepo = new CustomerRepo();

        Plugin.Media.Abstractions.MediaFile file;
        byte[] bytes;
        string base64str;
        CUSTOMER customer = new CUSTOMER();

        firebaseThing FireBaseClient = new firebaseThing();
        private bool emailValid;

        // private object firebaseHelper;
        private bool EmailValid { 
            get => emailValid; 
            set
            {
                emailValid = value;
                OnPropertyChanged();

            } 
        }
       
        public CreateAcc()
        {
            InitializeComponent();
            //s  this.BindingContext = new CreateAccountViewModel(this);
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            // signButton_Clicked.Clicked += signButton_Clicked;
            base.OnAppearing();

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        async public void ImageButton_Clicked(object sender, EventArgs e)
        {

            await CrossMedia.Current.Initialize();
            try
            {
                file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {

                    // PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight
                });
                if (file == null) { return; }


                //Imgresult.Source = ImageSource.FromStream(() =>
                //{

                //    var imageStream = file.GetStream();
                //    return imageStream;
                //});
            }
            catch (Exception ex)
            {

            }
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
        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
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

        async public void signButton_Clicked(System.Object sender, System.EventArgs e)
        {
           Random randomID = new Random();
            int CustomerID = randomID.Next(1, 10000);
            try
            {
               

                string firstName = entryField_Firstname.Text;
                string lastName = entryField_Lastname.Text;
                string middlename = entryField_Middlename.Text;
                string contactNumber = entryField_PhoneNumber.Text;
                string email = entryField_EmailAddress.Text;
                var dateOfBirth = entryField_DateOfBirth.Date.ToString().Split(" ")[0];
                string address = entryField_Address.Text;
                string password = entryField_Password.Text;
                string confirmpassword = entryField_ConfirmPassword.Text;
                string securityQuestion = entryField_SecurityQuestion.SelectedItem.ToString();
                string securityQuestion_answer = entryField_SecurityQuestionAnswer.Text;
               // string idType = selectedradioButton.Content.ToString();
                if (file != null)
                {
                    string image = await customerRepo.Upload(file.GetStream(), Path.GetFileName(file.Path));
                    customer.CusValiIdImage = image;
                }

                if (string.IsNullOrEmpty(firstName))
                {
                    // await this.DisplayToastAsync("Please Enter your First Name", 1500);
                    await this.DisplayAlert("Warning", "Please Enter your First Name", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(lastName))
                {
                    // await this.DisplayToastAsync("Please Enter your Last Name", 1500);
                    await this.DisplayAlert("Warning", "Please Enter your Last Name", "OK");
                    return;
                }
              
                if (string.IsNullOrEmpty(contactNumber))
                {
                    // await this.DisplayToastAsync("Please Enter your Contact Number", 1500);
                    await this.DisplayAlert("Warning", "Please Enter your Contact Number", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(email))
                {
                    // await this.DisplayToastAsync("Please Enter your Email", 1500);
                    await this.DisplayAlert("Warning", "Please Enter your Email", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(dateOfBirth))
                {
                    // await this.DisplayToastAsync("Please Enter your Date of Birth", 1500);
                    await this.DisplayAlert("Warning", "Please Enter your Date of Birth", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(address))
                {
                    // await this.DisplayToastAsync("Please Enter your Address", 1500);
                    await this.DisplayAlert("Warning", "Please Enter your Address", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    //   await this.DisplayToastAsync("Please Enter your Password", 1500);
                    await this.DisplayAlert("Warning", "Please Enter your Password", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(confirmpassword))
                {
                    //   await this.DisplayToastAsync("Please Enter your Password", 1500);
                    await this.DisplayAlert("Warning", "Please re-type your password", "OK");
                    return;
                }
                if (confirmpassword != password)
                {
                    // await this.DisplayToastAsync("Password does not match", 1500);
                    await this.DisplayAlert("Warning", "Password does not match", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(securityQuestion))
                {
                    // await this.DisplayToastAsync("Please Select a Security Question", 1500);
                    await this.DisplayAlert("Warning", "Please Select a Security Question", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(securityQuestion_answer))
                {
                    // await this.DisplayToastAsync("Please Enter your answer", 1500);
                    await this.DisplayAlert("Warning", "Please Enter your answer", "OK");
                    return;
                }




                customer.CusID = Convert.ToString(CustomerID);
                //   customer.CusID =
                customer.CusFirstName = firstName;
                customer.CusLastName = lastName;
                customer.CusMiddleName = middlename;
                customer.CusEmail = email;
                customer.CusContactNumber = contactNumber;
                customer.CusAddress = address;

                customer.CusSecurityQuestion = securityQuestion;
                customer.CusSecurityQuestionAnswer = securityQuestion_answer;

                customer.CusPassword = password;
                customer.CusBirthOfDate = dateOfBirth;
               
                bool Savedata = await customerRepo.Save(customer);
                if (Savedata)
                {
                    //await this.DisplayToastAsync("Data has been Saved!", 1500);
                    await this.DisplayAlert("Register User", "Registration successfull", "OK");
                    ClearData();
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    // await this.DisplayToastAsync("Data cannot be Save!", 1500);
                    await this.DisplayAlert("Register User", "Registration failed", "OK");
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_EXISTS"))
                {
                    // await this.DisplayToastAsync("Email already Exist", 1500);
                    await DisplayAlert("Warning", "Email already exist.", "OK");
                  
                }
                else
                {
                    await DisplayAlert("Warning", ex.Message, "OK");
                }
            }

  

        }







        public void ClearData()
        {
            entryField_Firstname.Text = string.Empty;
            entryField_Lastname.Text = string.Empty;
            entryField_Middlename.Text = string.Empty;
            entryField_PhoneNumber.Text = string.Empty;
            entryField_EmailAddress.Text = string.Empty;

            entryField_DateOfBirth.clear();
            
            entryField_Address.Text = string.Empty;
           
            entryField_Password.Text = string.Empty;
            entryField_ConfirmPassword.Text = string.Empty;
           
            entryField_SecurityQuestionAnswer.Text = string.Empty;


        }


        
    }
}