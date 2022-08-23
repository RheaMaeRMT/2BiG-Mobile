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

            MainPage = new LoginPage();
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
