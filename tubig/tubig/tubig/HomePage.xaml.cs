using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public List<WRSinfo> AllStationInfo { get; set; }
        private OrderPagePopUp OrderPageModal;
        public HomePage()
        {
            InitializeComponent();
            PopupNavigation.Instance.Pushing += (sender, e) => Debug.WriteLine($"[Popup] Pushing: {e.Page.GetType().Name}");
            PopupNavigation.Instance.Pushed += (sender, e) => Debug.WriteLine($"[Popup] Pushed: {e.Page.GetType().Name}");
            PopupNavigation.Instance.Popping += (sender, e) => Debug.WriteLine($"[Popup] Popping: {e.Page.GetType().Name}");
            PopupNavigation.Instance.Popped += (sender, e) => Debug.WriteLine($"[Popup] Popped: {e.Page.GetType().Name}");

           OrderPageModal = new OrderPagePopUp();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AllStationInfo = new List<WRSinfo>(WRSinfo.Get());
            // collectionViewListHorizontal.ItemsSource = AllContacts;
            collectionViewListVertical.ItemsSource = AllStationInfo;
        }

        async private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            refreshview.IsRefreshing = false;
            refreshview.IsEnabled = false;
        }

        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //var loadingPage = new LoadingPopupPage(); TapGestureRecognizer_Tapped
            //await Navigation.PushPopupAsync(loadingPage);
            //await Task.Delay(2000);
            //await Navigation.RemovePopupPageAsync(loadingPage);
            //await Navigation.PushPopupAsync(new LoginSuccessPopupPage());

            //var loadingPage = new OrderPagePopUp();
            //await Navigation.PushModalAsync(loadingPage);
            //await Task.Delay(2000);  await PopupNavigation.Instance.PushAsync(_loginPopup);

            // var current = (e.CurrentSelection.FirstOrDefault() as Subjects);
            var stationname = ((TappedEventArgs)e).Parameter as WRSinfo;
            //var stationname = ta
            // await Navigation.PushAsync(new OrderProductReviewPagePopUp(stationname.storename)); //1st way
            // await PopupNavigation.Instance.PushAsync(OrderPageModal(stationname.storename));

            var modalpage = new OrderPagePopUp();
            modalpage.BindingContext = stationname;
            await PopupNavigation.Instance.PushAsync(modalpage);
            
            // await PopupNavigation.Instance.PushAsync(OrderPageModal);// original approach
        }
    }
}