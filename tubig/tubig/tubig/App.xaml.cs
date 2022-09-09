using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("DynaPuff-VariableFont_wdth,wght.ttf", Alias ="DynaPuff")]
namespace tubig
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage());
            //  MainPage = new NavigationPage(new ForgotPasswordPage());
            // MainPage = new NavigationPage(new MainPage());
             MainPage = new NavigationPage( new MainPage());
           //MainPage = new NavigationPage(new CreateAcc());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()  
        {
        }
    }
}
