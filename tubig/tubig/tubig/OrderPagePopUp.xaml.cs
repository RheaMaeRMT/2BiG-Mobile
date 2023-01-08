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

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPagePopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        
        public List<StationWaterProduct> StationWaterProduct { get; set; }///*water products display static data for now*/


        public List<WATER_GALLONS> AllGallonProduct { get; set; }// water gallon products na ge offer sa station, ang datas is from db na

        public List<Product_RefillRepo> allprodrefill { get; set; } //class which naa dire ang pag fetch sa data from db



        WATER_ORDER waterOrder = new WATER_ORDER(); 
        WRSinfo stationinfo = new WRSinfo();

        WaterOrderRepo waterorderRepos = new WaterOrderRepo(); 
        WaterGallonRepo watergallonRepos = new WaterGallonRepo();
        Product_RefillRepo productrefill = new Product_RefillRepo();
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
            CollectionViewList_GallonProduct.ItemsSource = watergallonproducts;// bind ang data sa GetAllWaterProduct(), ge bind sa ID sa collectionview

            allprodrefill = new List<Product_RefillRepo>(Product_RefillRepo.Get());
            // Picker_ProductType.ItemsSource = allprodrefill; 
            var productRefill = await productrefill.GetAllProductRefill();
            Picker_ProductType.ItemsSource = productRefill;
            Picker_ProductTypeTest.ItemsSource = productRefill;
           // labelNote.IsVisible = true;
        }

       

        void UpdateSelectionData(IEnumerable<object> previousSelectedContact, IEnumerable<object> currentSelectedContact)
        {
            var selectedContact = currentSelectedContact.FirstOrDefault() as Contacts;
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

                //1
                //LoginButton.Scale = 1;
                //LoginButton.Opacity = 1;

                //UsernameEntry.TranslationX = PasswordEntry.TranslationX = 0;
                //UsernameEntry.Opacity = PasswordEntry.Opacity = 1;

                return;
            }

            CloseImage.Rotation = 30;
            CloseImage.Scale = 0.3;
            CloseImage.Opacity = 0;

            //#2 comment
            //LoginButton.Scale = 0.3;
            //LoginButton.Opacity = 0;

            //UsernameEntry.TranslationX = PasswordEntry.TranslationX = -10;
            //UsernameEntry.Opacity = PasswordEntry.Opacity = 0;
        }

        protected override async Task OnAppearingAnimationEndAsync()
        {
            if (!IsAnimationEnabled)
                return;

            var translateLength = 400u;

            await Task.WhenAll(
              //  UsernameEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
              //  UsernameEntry.FadeTo(1),
                (new Func<Task>(async () =>
                {
                    //await Task.Delay(200);
                    //await Task.WhenAll(
                    //   PasswordEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
                    //   PasswordEntry.FadeTo(1));

                }))());

            //await Task.WhenAll(
            //    CloseImage.FadeTo(1),
            //    CloseImage.ScaleTo(1, easing: Easing.SpringOut),
            //   CloseImage.RotateTo(0),
            //   LoginButton.ScaleTo(1),
            //   LoginButton.FadeTo(1));

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

            //await Task.WhenAll(
            //    UsernameEntry.FadeTo(0),
            //    PasswordEntry.FadeTo(0),
            //    LoginButton.FadeTo(0));

            //FrameContainer.Animate("HideAnimation", d =>
            //{
            //    FrameContainer.HeightRequest = d;
            //},
            //start: currentHeight,
            //end: 170,
            //finished: async (d, b) =>
            //{
            //    await Task.Delay(300);
            //    taskSource.TrySetResult(true);
            //});

           // await taskSource.Task;
        }

       

        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            CloseAllPopup();
            //return true;
        }

        protected override bool OnBackgroundClicked()
        {
            CloseAllPopup();

            return false;
        }

        private async void CloseAllPopup()
        {
            await PopupNavigation.Instance.PopAllAsync();
        }

        private async  void PickerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string pickermode = PickerMode.Items;
            //if (pickermode == "Express")
            //{

            //}
            
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;

            if (selectedItem == "Standard")
            {
                // entryfieldReservationDate
               // entryfieldReservationDate.IsEnabled = false;
        
            }
            else if (selectedItem == "Reservation")
            {
               // entryfieldReservationDate.IsEnabled = true;
            }
            else if (selectedItem == "Express")
            {
                await DisplayAlert("Warning", "Note:Estimated delivery time is 20-30 mins.", "OK");
                
               // entryfieldReservationDate.IsEnabled = false;
            }
            else
            {
               //entryfieldReservationDate.IsEnabled = false;
            }
        }

         async private void Button_Clicked(object sender, EventArgs e)
         {
            var modalpage = new OrderPagePopUp();
            
            PRODUCT_REFILL prodrefill = Picker_ProductType.SelectedItem as PRODUCT_REFILL;
          //  Product_RefillRepo prodrefill = Picker_ProductType.SelectedItem as Product_RefillRepo;
            
          
            string orderStatus = "Pending";
            string deliveryType = Picker_DeliveryType.SelectedItem.ToString();
            string orderType = Picker_OrderType.SelectedItem.ToString();
            string orderQuantity =  entryField_Quantity.Text;
            string orderProductType = prodrefill.refillName;
            var orderDate = entryfieldReservationDate.Date.ToString().Split(" ")[0];

            // string orderProductType = Picker_ProductType.SelectedItem.ToString();



            // var storename = stationinfo.storename;
            //waterOrder.OrderFrom_store = storename;
            //waterOrder.OrderStatus = orderStatus;
            //waterOrder.DeliveryType = deliveryType;
            //waterOrder.OrderQuantity = orderQuantity;

            //waterOrder.OrderProductType = orderProductType;
            //waterOrder.OrderReservationDate = orderDate;

            //var Savedata = await customerRepo.Save(waterOrder);
            var SaveData = await waterorderRepos.Save(waterOrder);
            if (SaveData)
            {
                await this.DisplayToastAsync("Data has been Saved!", 1500);
                ClearData();

               // await Navigation.PopAsync(modalpage);
            }
            else
            {
                await this.DisplayToastAsync("Data can not be save!", 1500);
            }
            // string orderQuantity=
         }
        public void ClearData()
        {

            PRODUCT_REFILL prodrefill = Picker_ProductType.SelectedItem as PRODUCT_REFILL;
           // Picker_DeliveryType.Items.Clear();
           

            // Picker_ProductType.Items.Clear();
           

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            // string or
            // Product_RefillRepo prodrefill = Picker_ProductTypeTest.SelectedItem as Product_RefillRepo;
            PRODUCT_REFILL prodrefill = Picker_ProductTypeTest.SelectedItem as PRODUCT_REFILL;
            string orderproductype = prodrefill.refillName;
            waterOrder.OrderProductType = orderproductype;

            var SaveData = await waterorderRepos.Save(waterOrder);
            if (SaveData)
            {
                await this.DisplayToastAsync("Data has been Saved!", 1500);
                ClearData();
            }
            else
            {
                await this.DisplayToastAsync("Data can not be save!", 1500);
            }
        }


        //private void collectionViewListHorizontal_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        //{
        //    UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        //}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //}

        //// ### Methods for supporting animations in your popup page ###

        //// Invoked before an animation appearing
        //protected override void OnAppearingAnimationBegin()
        //{
        //    base.OnAppearingAnimationBegin();
        //}

        //// Invoked after an animation appearing
        //protected override void OnAppearingAnimationEnd()
        //{
        //    base.OnAppearingAnimationEnd();
        //}

        //// Invoked before an animation disappearing
        //protected override void OnDisappearingAnimationBegin()
        //{
        //    base.OnDisappearingAnimationBegin();
        //}

        //// Invoked after an animation disappearing
        //protected override void OnDisappearingAnimationEnd()
        //{
        //    base.OnDisappearingAnimationEnd();
        //}

        //protected override Task OnAppearingAnimationBeginAsync()
        //{
        //    return base.OnAppearingAnimationBeginAsync();
        //}

        //protected override Task OnAppearingAnimationEndAsync()
        //{
        //    return base.OnAppearingAnimationEndAsync();
        //}

        //protected override Task OnDisappearingAnimationBeginAsync()
        //{
        //    return base.OnDisappearingAnimationBeginAsync();
        //}

        //protected override Task OnDisappearingAnimationEndAsync()
        //{
        //    return base.OnDisappearingAnimationEndAsync();
        //}

        //// ### Overrided methods which can prevent closing a popup page ###

        //// Invoked when a hardware back button is pressed
        //protected override bool OnBackButtonPressed()
        //{
        //    // Return true if you don't want to close this popup page when a back button is pressed
        //    return base.OnBackButtonPressed();
        //}

        //// Invoked when background is clicked
        //protected override bool OnBackgroundClicked()
        //{
        //    // Return false if you don't want to close this popup page when a background of the popup page is clicked
        //    return base.OnBackgroundClicked();
        //}
    }
}