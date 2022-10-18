using GoogleApi.Entities.Search.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapTest : ContentPage
    {
        public MapTest()
        {
            InitializeComponent();
        }

         private async  void Button_Clicked(object sender, EventArgs e)
        {
            CancellationTokenSource cts;
            //try
            //{
            //    var location = await Geolocation.GetLastKnownLocationAsync();
            //    if (location == null)
            //    {
            //        location = await Geolocation.GetLocationAsync(new GeolocationRequest { 

            //            DesiredAccuracy=GeolocationAccuracy.Medium,
            //            Timeout=TimeSpan.FromSeconds(30)
            //        });

            //    }
            //    if (location == null)
            //    {
            //        labellocation.Text = "No GPS";
            //    }
            //    else
            //    {
            //        labellocation.Text = $"{location.Latitude} {location.Longitude}";
            //    }

            //}
            //catch(Exception ex)
            //{
            //    Debug.WriteLine($"Something is wrong:{ex.Message }");
            //}

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
               

                //var location = await Geolocation.GetLastKnownLocationAsync(request,cts.Token);
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                   // Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                   labellocation.Text = $"{location.Latitude} {location.Longitude} {location.Altitude}";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}