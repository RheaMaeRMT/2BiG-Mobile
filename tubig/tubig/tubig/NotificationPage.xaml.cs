using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using tubig.ViewModel;
namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage : ContentPage
    {
        public List<DeliveryInfo> AllContacts { get; set; }
        DeliveryRepo notif = new DeliveryRepo();
        CUSTOMERNOTIFICATIONrepo customerNotification = new CUSTOMERNOTIFICATIONrepo();
        CUSTOMERNOTIFICATION customernotifModel = new CUSTOMERNOTIFICATION();
     
        public NotificationPage()
        {
            ObservableCollection<DeliveryInfo>   station;
            InitializeComponent();
           
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            AllContacts = new List<DeliveryInfo>(DeliveryInfo.Get());

            var customernotif = await customerNotification.GetAllOrderData();
            collectionViewListVertical.ItemsSource = customernotif;

        }

        private void myCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

    

        private void collectionViewListVertical_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new OrderDetails());
            
          
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var customernotif = await customerNotification.GetCustomerNotificationUpdated();
            collectionViewListVertical.ItemsSource = customernotif;
        }
    }
}