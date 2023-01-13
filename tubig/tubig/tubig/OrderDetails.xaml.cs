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
    public partial class OrderDetails : ContentPage
    {

        CUSTOMERNOTIFICATIONrepo customernotif = new CUSTOMERNOTIFICATIONrepo();
        DeliveryRepo notif = new DeliveryRepo();
        public List<DeliveryInfo> AllContacts { get; set; }
        public OrderDetails()
        {
            InitializeComponent();
        }

        private void collectionViewListVertical_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            var orderdetailsToDisplay = await customernotif.GetCustomerNotification();
         //var deliveryRepo = await deliveryRepos.GetAllDeliveryData();
           // Picker_DeliveryType.ItemsSource = deliveryRepo;
            AllContacts = new List<DeliveryInfo>(DeliveryInfo.Get());
            // collectionViewListHorizontal.ItemsSource = AllContacts;
        //  collectionViewListVertical.ItemsSource = AllContacts;
           // var deliveryRepo = await notif.getAllCustomerNotif();
            collectionViewListVertical.ItemsSource = orderdetailsToDisplay;
        }

        

        private void SwipeItem_Invoked_1(object sender, EventArgs e)
        {

        }
    }
}