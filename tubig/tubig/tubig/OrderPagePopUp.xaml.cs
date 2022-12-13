using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;


using Rg.Plugins.Popup.Pages;
using tubig.DataModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace tubig
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderProductReviewPagePopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        public List<StationWaterProduct> AllStationInfo { get; set; }
        public List<StationGallonProducts> AllGallonProduct { get; set; }
        public OrderProductReviewPagePopUp()
        {
            InitializeComponent();
            //entryfieldReservationDate.IsEnabled = true;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AllStationInfo = new List<StationWaterProduct>(StationWaterProduct.Get());
            AllGallonProduct = new List<StationGallonProducts>(StationGallonProducts.Get());

           collectionViewListHorizontal.ItemsSource = AllStationInfo;
           CollectionViewList_GallonProduct.ItemsSource = AllGallonProduct;
        }

        //void CollectionViewListSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        //}

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

        //private async void OnLogin(object sender, EventArgs e)
        //{
        //    var loadingPage = new LoadingPopupPage();
        //    await Navigation.PushPopupAsync(loadingPage);
        //    await Task.Delay(2000);
        //    await Navigation.RemovePopupPageAsync(loadingPage);
        //    await Navigation.PushPopupAsync(new LoginSuccessPopupPage());
        //}

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

        private void PickerMode_SelectedIndexChanged(object sender, EventArgs e)
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

               // entryfieldReservationDate.IsEnabled = true;
        
            }
            else if (selectedItem == "Reservation")
            {
                //entryfieldReservationDate.IsEnabled = true;
            }
            else
            {
               // entryfieldReservationDate.IsEnabled = false;
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