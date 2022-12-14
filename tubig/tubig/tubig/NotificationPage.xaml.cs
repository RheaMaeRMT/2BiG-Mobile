using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage : ContentPage
    {
        public List<DeliveryInfo> AllContacts { get; set; }
        public NotificationPage()
        {
            ObservableCollection<DeliveryInfo>   station;
            InitializeComponent();
            //List<StationInfo> MyList = new List<StationInfo>
            //{
            //    new StationInfo{StationName="Dici's Station ", distance="2km",status="Open",ImageURL="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVeHpqAzsHvQnO0XMKCUKYq0-rrCP6h8GXOM3BF5QMHPB7mqk&s"},

            //     new StationInfo{StationName="Ja's Station ", distance="5km",status="Open",ImageURL="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVeHpqAzsHvQnO0XMKCUKYq0-rrCP6h8GXOM3BF5QMHPB7mqk&s"},

            //      new StationInfo{StationName="Rhea's Station ", distance="4km",status="Close",ImageURL="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVeHpqAzsHvQnO0XMKCUKYq0-rrCP6h8GXOM3BF5QMHPB7mqk&s"}
            //};
            //MyListView.ItemsSource = MyList;
            //station = new ObservableCollection<StationInfo>
            //{
            //    new StationInfo{StationName="Ja's WRS incomming delivery", estimatedtime="20mins",ImageURL="shopnew.png", distance="2km"},
            //    new StationInfo{StationName="Dici's WRS incomming delivery", estimatedtime="20mins", ImageURL="shopnew.png"},
            //};
          //  myCollectionView.ItemsSource = station;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AllContacts = new List<DeliveryInfo>(DeliveryInfo.Get());
           // collectionViewListHorizontal.ItemsSource = AllContacts;
            collectionViewListVertical.ItemsSource = AllContacts;
        }

        private void myCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selecteditem = e.CurrentSelection[0] as StationInfo;
            //if(selecteditem != null)
            //{
            //    DisplayAlert("Station", $"{selecteditem.StationName}", "OK");
            //}
        }

       //async private void SwipeItem_Invoked(object sender, EventArgs e)
       // {
       //     await Navigation.PushAsync(new Order());
       //     await NavigationPage = new NavigationPage(new Order());
       //     await Navigation.PushAsync(new LoginPage());
       //     DisplayAlert("Add", "Test", "OK");
       // }

        private void collectionViewListVertical_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // StationInfo myvalue= e.CurrentSelection.FirstOrDefault() as StationInfo;
          //  App.Current.MainPage.Navigation.PushAsync(new Order());

        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            //await NavigationPage = new NavigationPage(new Order());
            // await Navigation.PopAsync(Order());
            //await Navigation.PopAsync(Order);
            //NavigationPage.SetHasNavigationBar(new MainPage());
            await Navigation.PushAsync(new Order());
            //await NavigationPage = new NavigationPage(new Order());
            //  await Navigation.PopAsync(new Order());
            //   await NavigationPage = new NavigationPage(new Order());
            // await Navigation.PopAsync(new Order());
            //public System.Threading.Tasks.Task<Xamarin.Forms.Page> PopAsync(bool animated);

           // await _page.CurrentPage.Navigation.PopToRootAsync();
        }
    }
}