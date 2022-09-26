using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
       // StationInfo myvalue = new StationInfo();
        public MapPage()
        {
            InitializeComponent();
             //myvalue = place;
        }
    }
}