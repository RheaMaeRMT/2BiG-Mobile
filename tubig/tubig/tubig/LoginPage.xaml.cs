using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms.Xaml;
using tubig.DataModel;
using Xamarin.Essentials;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        CUSTOMER customerModel = new CUSTOMER();
        CustomerRepo CustomerRepo = new CustomerRepo();
        public LoginPage()
        {
            InitializeComponent();
        

        }
         protected override void OnAppearing()
        {
         
        }

        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ForgotPasswordPage());
        }

         async  private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAcc());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           
            try
            {
                var email = EmailTextbox.Text;
                var password = password_Textbox.Text;
                if (string.IsNullOrEmpty(email) )
                {
                await DisplayAlert("Warning", "Please Enter your Email", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Warning", "Please Enter your Password", "OK");
                    return;
                }
                var token = await CustomerRepo.Signin(email, password);
                if (!string.IsNullOrEmpty(token))

                {
                    string Email = email;
                    var customer = await CustomerRepo.GetCustomerByEmail(Email, password);
                    customerModel.CusID = customer.CusID;
                    customerModel.CusEmail = customer.CusEmail;
                    customerModel.CusFirstName = customer.CusFirstName;
                     customerModel.CusLastName = customer.CusLastName;
                    
                   customerModel.CusMiddleName = customer.CusMiddleName;
                    customerModel.CusContactNumber = customer.CusContactNumber;
                
                    customerModel.CusBirthOfDate = customer.CusBirthOfDate;
                    customerModel.CusAddress = customer.CusAddress;
                   
                    Preferences.Set("token", token);
                    Preferences.Set("customerEmail", email);
                    Preferences.Set("customerID", customerModel.CusID);
                    Preferences.Set("customerFirstname", customerModel.CusFirstName);
                    Preferences.Set("customerMiddlename", customerModel.CusMiddleName);
                    Preferences.Set("customerLastname", customerModel.CusLastName);
                    Preferences.Set("customerFullname", customer.CusFirstName + " " + customer.CusMiddleName + " " + customer.CusLastName);
                    Preferences.Set("customerContactNumber", customerModel.CusContactNumber);
                    Preferences.Set("customerDOB", customerModel.CusBirthOfDate);
                    Preferences.Set("customerAddress", customerModel.CusAddress);
                    await DisplayAlert("Login", "Login Successfully", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Sign In", "Sign in failed", "ok");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    await DisplayAlert("Unauthorized", "Email not found", "OK");
                }
                else if (ex.Message.Contains("INVALID_PASSWORD"))
                {
                    await DisplayAlert("Unauthorized", "Password incorrect", "OK");
                }
                else
                {
                   // await DisplayAlert("Error", ex.Message, "OK");
                    await DisplayAlert("Error", "Invalid Login", "OK");
                }
            }
           

        }

       
    }
}