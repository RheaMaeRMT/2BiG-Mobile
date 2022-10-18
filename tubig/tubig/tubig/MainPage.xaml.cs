using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace tubig
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
             InitializeComponent();
            //LoginPage = new NavigationPage(LoginPage);
            //MainPage = new NavigationPage(new LoginPage());
            //LoginPage();
           CurrentPage =Children[2];
        //  TabbedPage.
       // android: TabbedPage.ToolbarPlacement = "Bottom";

           // OpenMap.
        }
        async void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
           // await Navigation.PopAsync(new Order());
        }

        async void OnRootPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        // public NavigationPage MainPage { get; }
    }
}
