using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
            await Navigation.PushAsync(new MainPage());
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