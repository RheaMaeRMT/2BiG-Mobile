using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using System.Reflection;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using Map = Xamarin.Essentials.Map;
using System.Diagnostics;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAcc_AddressMap : ContentPage
    {
        public  CreateAcc_AddressMap()
        {
            InitializeComponent();

           
        }

        private async  void myMap_MapClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync();
                }
                    
            }
            catch(Exception ex)
            {
                // Debug.Writeline($""Something is Wrong:{ex.Message}");
                Debug.WriteLine($"Something is wrong:{ex.Message}");
            }
        }
    }
}