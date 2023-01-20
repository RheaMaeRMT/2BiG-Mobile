using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetails : ContentPage
    {
        ORDER orderDetails = new ORDER();
        CUSTOMERNOTIFICATIONrepo customernotif = new CUSTOMERNOTIFICATIONrepo();
        DeliveryRepo notif = new DeliveryRepo();
        ADMINNOTIFICATION adminNotify = new ADMINNOTIFICATION();
        ADMINNOTIFICATIONrepo adminNotifyRepo = new ADMINNOTIFICATIONrepo();
        CUSTOMER customer = new CUSTOMER();
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
            var orderdetailsToDisplay = await customernotif.GetAllOrderData();
        
            AllContacts = new List<DeliveryInfo>(DeliveryInfo.Get());
          
            collectionViewListVertical.ItemsSource = orderdetailsToDisplay;
        }

        

       

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var customernotify = await customernotif.GetCustomerNotificationUpdated();
            collectionViewListVertical.ItemsSource = customernotify;
        }

        private async void swipe_orderstatus_Invoked_1(object sender, EventArgs e)
        {
            Random randomID = new Random();
            int order_ID = randomID.Next(1, 10000);
            int adminNotifID = randomID.Next(1, 1000);
            string newOrderStatus = "Received";
            var orderCustomerID = Convert.ToInt32(Preferences.Get("customerID", customer.CusID));
            string order_id = ((MenuItem)sender).CommandParameter.ToString();
            var order = await adminNotifyRepo.GetById(order_id);
            var ORDER_DETAILS = await customernotif.GetAllOrderData();
            if (order == null)
            {
                await DisplayAlert("Warning", "Data not found.", "Ok");
            }

            // adminNotify.orderFrom_store= 
            adminNotify.orderDeliveryType = order.orderDeliveryType;
            adminNotify.orderFrom_store = order.orderFrom_store;
            adminNotify.orderType = order.orderType;
            adminNotify.OrderProductType = order.OrderProductType;
            adminNotify.OrderReservationDate = order.OrderReservationDate;
            adminNotify.orderDateTime = order.orderDateTime;
            adminNotify.orderQuantity = order.orderQuantity;
            adminNotify.orderTotalAmount = order.orderTotalAmount;
            adminNotify.orderPrice = order.orderPrice;
            //mo gana na
            adminNotify.orderID = order_id;
            adminNotify.order_CUSTOMERID = orderCustomerID;
            adminNotify.adminnotificationID = adminNotifID;
            adminNotify.OrderStatus = newOrderStatus; //
            // var SaveData = await waterorderRepos.Save(waterOrder);
            var SaveData = await adminNotifyRepo.SaveToAdminNotification(adminNotify);
            if (SaveData)
            {
                await this.DisplayAlert("", "Thank you for confirming", "OK");
              
                return;

            }
            else
            {
                await this.DisplayAlert("", "Error", "OK");
            }

        }

       async  private void swipe_orderstatus_notReceive_Invoked(object sender, EventArgs e)
        {
            Random randomID = new Random();
           // int order_ID = randomID.Next(1, 10000);
            int adminNotifID = randomID.Next(1, 1000);
            string newOrderStatus = "Not receive";
            var orderCustomerID = Convert.ToInt32(Preferences.Get("customerID", customer.CusID));
            string order_id = ((MenuItem)sender).CommandParameter.ToString();
            var order = await adminNotifyRepo.GetById(order_id);
            var ORDER_DETAILS = await customernotif.GetAllOrderData();
            if (order == null)
            {
                await DisplayAlert("Warning", "Data not found.", "Ok");
            }

            // adminNotify.orderFrom_store= 
            adminNotify.orderDeliveryType = order.orderDeliveryType;
            adminNotify.orderFrom_store = order.orderFrom_store;
            adminNotify.orderType = order.orderType;
            adminNotify.OrderProductType = order.OrderProductType;
            adminNotify.OrderReservationDate = order.OrderReservationDate;
            adminNotify.orderDateTime = order.orderDateTime;
            adminNotify.orderQuantity = order.orderQuantity;
            adminNotify.orderTotalAmount = order.orderTotalAmount;
            //mo gana na
            adminNotify.orderID = order_id;
            adminNotify.order_CUSTOMERID = orderCustomerID;
            adminNotify.adminnotificationID = adminNotifID;
            adminNotify.OrderStatus = newOrderStatus; //
            // var SaveData = await waterorderRepos.Save(waterOrder);
            var SaveData = await adminNotifyRepo.SaveToAdminNotification(adminNotify);
            if (SaveData)
            {
                await this.DisplayAlert("", "Thank you for confirming", "OK");

                return;

            }
            else
            {
                await this.DisplayAlert("", "Error", "OK");
            }
        }
    }
}