using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tubig.DataModel;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPagePopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        
        public List<StationWaterProduct> StationWaterProduct { get; set; }///*water products display static data for now*/


        public List<PRODUCTREPO> allprodrefill { get; set; } //class which naa dire ang pag fetch sa data from db

        PRODUCT allproduct = new PRODUCT();
        DELIVERY deliveryModel = new DELIVERY();
        ORDER waterOrder = new ORDER(); 
        WRSinfo stationinfo = new WRSinfo();
        CUSTOMER customer = new CUSTOMER();
        ADMINNOTIFICATION adminNotification = new ADMINNOTIFICATION();

        OrderRepo waterorderRepos = new OrderRepo(); 
        WaterGallonRepo watergallonRepos = new WaterGallonRepo();
        PRODUCTREPO productRepo = new PRODUCTREPO();
        DeliveryRepo deliveryRepos = new DeliveryRepo();
      
       

        public OrderPagePopUp()
        {
            InitializeComponent();
            
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            StationWaterProduct = new List<StationWaterProduct>(DataModel.StationWaterProduct.Get());
           // AllGallonProduct = new List<StationGallonProducts>(StationGallonProducts.Get());
           collectionViewListHorizontal.ItemsSource = StationWaterProduct;  //ge bind ang data sa allstationinfoo padung ID sa collection view, pag display na sa  station  water info


            var watergallonproducts = await watergallonRepos.GetAllWaterProduct();
            //CollectionViewList_GallonProduct.ItemsSource = watergallonproducts;// bind ang data sa GetAllWaterProduct(), ge bind sa ID sa collectionview

            allprodrefill = new List<PRODUCTREPO>(PRODUCTREPO.Get());
            
            var product_Data = await productRepo.GetAllPRODUCTData();
            var deliveryRepo = await deliveryRepos.GetAllDeliveryData();
            Picker_DeliveryType.ItemsSource = deliveryRepo;
            Picker_ProductType.ItemsSource = product_Data;
            collectionViewListHorizontal.ItemsSource = product_Data;
           

            labelTotalAmount.IsVisible = true;
           // labelProductPrice.Text = "₱" + allproduct.productPrice;


        }

       

        void UpdateSelectionData(IEnumerable<object> previousSelectedContact, IEnumerable<object> currentSelectedContact)
        {
            var selectedContact = currentSelectedContact.FirstOrDefault() as DataModel.Contacts;
            Debug.WriteLine("FullName: " + selectedContact.FullName);
            Debug.WriteLine("Email: " + selectedContact.Email);
            Debug.WriteLine("Phone: " + selectedContact.Phone);
            Debug.WriteLine("Country: " + selectedContact.Country);
        }

        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();

          //  FrameContainer.HeightRequest = -1; //-1

            if (!IsAnimationEnabled)
            {
                CloseImage.Rotation = 0;
                CloseImage.Scale = 1;
                CloseImage.Opacity = 1; //1

              
                return;
            }

            CloseImage.Rotation = 30;
            CloseImage.Scale = 0.3;
            CloseImage.Opacity = 0;

           
        }

        protected override async Task OnAppearingAnimationEndAsync()
        {
            if (!IsAnimationEnabled)
                return;

            var translateLength = 400u;

            await Task.WhenAll(
             
                (new Func<Task>(async () =>
                {
                  

                }))());


            await Task.WhenAll(
                CloseImage.FadeTo(1),
                CloseImage.ScaleTo(1, easing: Easing.SpringOut),
               CloseImage.RotateTo(0));

        }

        protected override async Task OnDisappearingAnimationBeginAsync()
        {
            if (!IsAnimationEnabled)
                return;

            var taskSource = new TaskCompletionSource<bool>();

            var currentHeight = FrameContainer.Height;

           
        }

       

        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            CloseAllPopup();
            //return true;
        }

        protected override bool OnBackgroundClicked()
        {
            CloseAllPopup();
           // await Navigation.PushAsync(new HomePage());
            return false;
        }

        private async void CloseAllPopup()
        {
            await PopupNavigation.Instance.PopAllAsync();
        }

        

        async private void Button_Clicked(object sender, EventArgs e)
        {
            DELIVERY deliverySave = Picker_DeliveryType.SelectedItem as DELIVERY;

        
            var modalpage = new OrderPagePopUp();
            Random randomID = new Random();
            int order_ID = randomID.Next(1, 10000);
            int adminNotifID = randomID.Next(1, 1000);
            
            const string timeFormatt = "";
            const string reservationDate = "No Date";
            DateTime currentDate = DateTime.Now;
            Picker pickerOfDeliveryType = sender as Picker;
         



            var note = deliverySave.deliveryFee;

           

            
            PRODUCT chooseProductType = Picker_ProductType.SelectedItem as PRODUCT;
            string selectedProductItem = chooseProductType.productType;
            string selectedDeliveryType = deliverySave.deliveryType;
           
            string deliveryType = deliverySave.deliveryType;
            string order_Type = Picker_OrderType.SelectedItem.ToString();
            int order_Quantity = Convert.ToInt32(entryField_Quantity.Text);
            string orderProduct_Type = chooseProductType.productType;
            var orderDate = entryfieldReservationDate.Date.ToString().Split("")[0];
        


            var orderCustomerID = Convert.ToInt32(Preferences.Get("customerID", customer.CusID));

            if (selectedDeliveryType == "Standard")
            {
               
                entryfieldReservationDate.IsEnabled = false;
                
                if (selectedProductItem == "Mineral")
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = "Total Amount: " + Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                    waterOrder.orderPrice = productprice;

                }
                else
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = "Total Amount: " + Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                    waterOrder.orderPrice = productprice;

                }
                waterOrder.OrderReservationDate = "No Date";
                
            }
            else if (selectedDeliveryType == "Reservation")
            {
                if (selectedProductItem == "Mineral")
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = "Total Amount: " + Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                    waterOrder.orderPrice = productprice;
                    
                }
                else
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = "Total Amount: " + Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                    waterOrder.orderPrice = productprice;

                }
               // waterOrder.OrderReservationDate = reservationDate;
            }
            else
            {
               
                entryfieldReservationDate.IsEnabled = false;
                int deliveryfee = deliverySave.deliveryFee;
                if (selectedProductItem == "Mineral")
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity+ deliveryfee;
                    int totalprice = subtotal;
                    labelTotalAmount.Text ="Total Amount: " +Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                    waterOrder.orderPrice = productprice;

                }
                else
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity+ deliveryfee;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = "Total Amount: " + Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                    waterOrder.orderPrice = productprice;

                }
                // waterOrder.OrderReservationDate = reservationDate;
                waterOrder.OrderReservationDate = "No Date";
               
            }

            waterOrder.orderFrom_store = lblTextStorname.Text;
            waterOrder.orderID = order_ID.ToString();
           
            waterOrder.orderDeliveryType = deliveryType;
            waterOrder.orderType = order_Type;
            waterOrder.orderQuantity = order_Quantity;
            waterOrder.OrderProductType = orderProduct_Type;
           
             waterOrder.order_CUSTOMERID = orderCustomerID;
            waterOrder.OrderStatus = "Pending";
            waterOrder.orderDateTime =  currentDate.ToString();
            var SaveData = await waterorderRepos.Save(waterOrder);


            adminNotification.OrderStatus = "Pending";
          //  adminNotification.orderID = order_ID;     
            adminNotification.adminnotificationID = adminNotifID;
           // var SaveDataToCustomerNotification = await waterorderRepos.SaveCustomerNotification(adminNotification);
            if (SaveData)
            {
                await this.DisplayAlert("Order", "Order successfully", "OK");
                ClearData();
                CloseAllPopup();
                return;

            }
            else
            {
                await this.DisplayAlert("Order", "We cannot process your order at the moment.", "OK");
                ClearData();
                CloseAllPopup();
                return;
            }

        }
        public void ClearData()
        {

            // PRODUCT_REFILL prodrefill = Picker_ProductType.SelectedItem as PRODUCT_REFILL;
            DELIVERY deliverySave = Picker_DeliveryType.SelectedItem as DELIVERY;
            string selectedDeliveryType = deliverySave.deliveryType;

            Picker_OrderType.Items.Clear();
            entryField_Quantity.Text = string.Empty;
            
        }
      

        private  void Picker_ProductType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PRODUCT prod = Picker_ProductType.SelectedItem as PRODUCT;
            var selectedProductItem = prod.productType;
            var productPricing = prod.productPrice.ToString();

            if (selectedProductItem == "Mineral")
            {
                labelProductPrice.Text = "Product Price: " + productPricing;
            }
            else
            {
                // labelProductPrice.Text = Convert.ToString(productPricing);
                labelProductPrice.Text = "Product Price: " + productPricing;
            }
        }

        private async void Picker_DeliveryType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DELIVERY deliverySave = Picker_DeliveryType.SelectedItem as DELIVERY;
            var selectedDeliveryItem = deliverySave.deliveryType;
            var note = deliverySave.deliveryFee;

             if (selectedDeliveryItem == "Standard")
            {

                await DisplayAlert("Note", "Within the day", "OK");
                entryfieldReservationDate.IsEnabled = false;
            }
            else if (selectedDeliveryItem == "Reservation")
            {
                await DisplayAlert("Note", "Enter reservation date below", "OK");
                entryfieldReservationDate.IsEnabled = true;
            }
            else 
            {
                entryfieldReservationDate.IsEnabled = false;
                await DisplayAlert("Note", "Estimated Delivery: 2 hours from now", "OK");
                labelDeliveryFee.Text = "Delivery Fee: " + note;
                

            }
        }

        
    }
}