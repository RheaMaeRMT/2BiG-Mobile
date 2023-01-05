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


            //MainPage = new NavigationPage(new ForgotPasswordPage());
            // MainPage = new MainPage(); // mao ni ang default start up
            // MainPage = new NavigationPage( new MainPage());

            // MainPage = new NavigationPage( new NotificationPage());
            // Forms.SetFlags("CollectionView_Experimental");
            //  MainPage = new NavigationPage(new MapTest());

           
          //MainPage = new NavigationPage(new RuntestforPopUp());


          // MainPage = new NavigationPage(new CreateAcc());
          //  MainPage = new NavigationPage(new MapPage());
           // MainPage = new NavigationPage(new LoginPage());
             MainPage = new NavigationPage(new MainPage());
            // MainPage = new MainPage();
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
