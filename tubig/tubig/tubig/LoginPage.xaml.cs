using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms.Xaml;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            // labelClickFunction();
           //   ToolbarItem.IsEnabledProperty = false;
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
            //  await btn_login.FadeTo(0, 1000, Easing.Linear);
            // await btn_login.FadeTo(1, 1000, Easing.Linear);



            var userName = usernameTextbox.Text;
            var password = password_Textbox.Text;
            string UserName = "admin";
            string Password = "admin";

            //if((userName != UserName) && (password != Password))
            //{
            //    await this.DisplayToastAsync("Invalid Username and Password", 10000);
            //}
             await Navigation.PushAsync(new MainPage());
            //await this.DisplayPromptAsync("Hellow world", "10000");
          //  await this.DisplayToastAsync("Invalid Username and Password", 10000);

        }

        //async public void labelClickFunction()
        //{
        //    //lbl_forgotpass.GestureRecognizers.Add(new TapGestureRecognizer()
        //    //{
        //    //    Command = new Command(() =>
        //    //      {
        //    //        // await Navigation.PushAsync(new ForgotPasswordPage());
        //    //        // DisplayAlert("Warning", "Test", "Ok");
        //    //    })

        //    //});


        //}


    }
}