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


     //   public List<WATER_GALLONS> AllGallonProduct { get; set; }// water gallon products na ge offer sa station, ang datas is from db na

        public List<PRODUCTREPO> allprodrefill { get; set; } //class which naa dire ang pag fetch sa data from db

        PRODUCT allproduct = new PRODUCT();
        DELIVERY deliveryModel = new DELIVERY();
        ORDER waterOrder = new ORDER(); 
        WRSinfo stationinfo = new WRSinfo();
        CUSTOMER customer = new CUSTOMER();
        CUSTOMERNOTIFICATION customerNotification = new CUSTOMERNOTIFICATION();

        OrderRepo waterorderRepos = new OrderRepo(); 
        WaterGallonRepo watergallonRepos = new WaterGallonRepo();
        PRODUCTREPO productRepo = new PRODUCTREPO();
        DeliveryRepo deliveryRepos = new DeliveryRepo();
       // WATER_GALLONS watergallonrepos = new WaterGallonRepo();
       
        public OrderPagePopUp()
        {
            InitializeComponent();
            //entryfieldReservationDate.IsEnabled = true;
            
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            StationWaterProduct = new List<StationWaterProduct>(DataModel.StationWaterProduct.Get());
           // AllGallonProduct = new List<StationGallonProducts>(StationGallonProducts.Get());
           collectionViewListHorizontal.ItemsSource = StationWaterProduct;  //ge bind ang data sa allstationinfoo padung ID sa collection view, pag display na sa  station  water info


            //CollectionViewList_GallonProduct.ItemsSource = AllGallonProduct;

            var watergallonproducts = await watergallonRepos.GetAllWaterProduct();
            //CollectionViewList_GallonProduct.ItemsSource = watergallonproducts;// bind ang data sa GetAllWaterProduct(), ge bind sa ID sa collectionview

            allprodrefill = new List<PRODUCTREPO>(PRODUCTREPO.Get());
            // Picker_ProductType.ItemsSource = allprodrefill; 
            var product_Data = await productRepo.GetAllPRODUCTData();
            var deliveryRepo = await deliveryRepos.GetAllDeliveryData();
            Picker_DeliveryType.ItemsSource = deliveryRepo;
            Picker_ProductType.ItemsSource = product_Data;
            collectionViewListHorizontal.ItemsSource = product_Data;
            //labelNote.IsVisible = true;

            labelTotalAmount.IsVisible = true;
           
         
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

        //private async  void PickerMode_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    DELIVERY delivery_Model = Picker_DeliveryType.SelectedItem as DELIVERY;

        //    Picker picker = sender as Picker;
        //    var selectedItem = picker.SelectedItem;

        //    if (selectedItem=="Standard")
        //    {

        //        entryField_Quantity.IsEnabled = true;
        //    }
        //    else if (selectedItem == "Reservation")
        //    {

        //    }
        //    else if (selectedItem == "Express")
        //    {
        //        await DisplayAlert("Warning", "Note:Estimated delivery time is 20-30 mins.", "OK");


        //    }
        //    else
        //    {

        //    }
        //}

        async private void Button_Clicked(object sender, EventArgs e)
        {
            DELIVERY deliverySave = Picker_DeliveryType.SelectedItem as DELIVERY;
            var modalpage = new OrderPagePopUp();
            Random randomID = new Random();
            int order_ID = randomID.Next(1, 10000);

            Picker pickerOfDeliveryType = sender as Picker;
          // pickerOfDeliveryType as SelectedItemChangedEventArgs += pickerOfDeliveryType



            var note = deliverySave.deliveryFee;

            //PRODUCT_REFILL prodrefill = Picker_ProductType.SelectedItem as PRODUCT_REFILL;

         
            PRODUCT chooseProductType = Picker_ProductType.SelectedItem as PRODUCT;
            string selectedProductItem = chooseProductType.productType;
            string selectedDeliveryType = deliverySave.deliveryType;
            string orderStatus = "Pending";
            string deliveryType = deliverySave.deliveryType;
            string order_Type = Picker_OrderType.SelectedItem.ToString();
            int order_Quantity = Convert.ToInt32(entryField_Quantity.Text);
            string orderProduct_Type = chooseProductType.productType;
            var orderDate = entryfieldReservationDate.Date.ToString().Split(" ")[0];
          //  var orderCustomerID = Convert.ToInt32(Preferences.Get("customerID", customer.CusID));

            if (selectedDeliveryType == "Standard")
            {
                if (selectedProductItem == "Mineral")
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                }
                else
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                }
            }
            else if (selectedDeliveryType == "Reservation")
            {
                if (selectedProductItem == "Mineral")
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                }
                else
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                }
            }
            else
            {
                int deliveryfee = deliverySave.deliveryFee;
                if (selectedProductItem == "Mineral")
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity+ deliveryfee;
                    int totalprice = subtotal;
                    labelTotalAmount.Text ="Total Amount:" +Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                }
                else
                {
                    int productprice = chooseProductType.productPrice;
                    int subtotal = productprice * order_Quantity+ deliveryfee;
                    int totalprice = subtotal;
                    labelTotalAmount.Text = Convert.ToString(totalprice);
                    waterOrder.orderTotalAmount = totalprice;
                }

            }

            waterOrder.orderID = order_ID;
            waterOrder.OrderStatus = orderStatus;
            waterOrder.orderDeliveryType = deliveryType;
            waterOrder.orderType = order_Type;
            waterOrder.orderQuantity = order_Quantity;
            waterOrder.OrderProductType = orderProduct_Type;
            waterOrder.OrderReservationDate = orderDate;
          //  waterOrder.order_CUSTOMERID = orderCustomerID;
            var SaveData = await waterorderRepos.Save(waterOrder);

            customerNotification.orderStatus = waterOrder.OrderStatus;
            customerNotification.order_CUSTOMERID = waterOrder.order_CUSTOMERID;
            customerNotification.orderID = waterOrder.orderID;
            customerNotification.orderDeliveryType = waterOrder.orderDeliveryType;
            customerNotification.orderType = waterOrder.orderType;
            customerNotification.orderQuantity = waterOrder.orderQuantity;
            customerNotification.OrderProductType = waterOrder.OrderProductType;
            customerNotification.OrderReservationDate = waterOrder.OrderReservationDate;
            customerNotification.order_CUSTOMERID = waterOrder.order_CUSTOMERID;
            customerNotification.customernotificationID = order_ID;
            var SaveDataToCustomerNotification = await waterorderRepos.SaveCustomerNotification(customerNotification);
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

        private async void Picker_DeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DELIVERY deliverySave = Picker_DeliveryType.SelectedItem as DELIVERY;
            var selectedDeliveryItem = deliverySave.deliveryType;
            var note = deliverySave.deliveryFee;
            
            if(selectedDeliveryItem == "Express")
            {
                
                await DisplayAlert("Note", "Estimated Delivery: 2 hours from now", "OK");
                labelDeliveryFee.Text = "Delivery Fee:" + note;
                entryfieldReservationDate.IsEnabled = false;
               
            }
            else if(selectedDeliveryItem == "Standard")
            {
               
                await DisplayAlert("Note", "Within the day", "OK");
                entryfieldReservationDate.IsEnabled = true;
            }
            else
            {
                await DisplayAlert("Note", "Enter Reservation Date", "OK");
                entryfieldReservationDate.IsEnabled = true;
            }
          
        }

        private void Picker_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            PRODUCT prod = Picker_ProductType.SelectedItem as PRODUCT;
            var selectedProductItem = prod.productType;
            var productPricing = prod.productPrice;

            if (selectedProductItem == "Mineral")
            {
                labelProductPrice.Text = Convert.ToString(productPricing);
            }
            else
            {
                labelProductPrice.Text = Convert.ToString(productPricing);
            }
        }

        //private void Picker_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var picker = (Picker)sender;
        //    int selectedIndex = picker.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        labelTotalAmount.Text = picker.Items[selectedIndex];
        //    }
        //}
    }
}