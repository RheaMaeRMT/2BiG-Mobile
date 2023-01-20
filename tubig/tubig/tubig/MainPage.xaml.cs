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
          
           CurrentPage =Children[2];
       
        }
        async void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
          
        }

        async void OnRootPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
       
    }
}
