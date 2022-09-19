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
            CurrentPage = Children[2];
           

        }

       // public NavigationPage MainPage { get; }
    }
}
