using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using tubig.DataModel;

namespace tubig
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DELIVERY> Deliveries { get; set; }
        private DELIVERY _deliverySelectedItem;
        public DELIVERY DeliverySelectedItem
        {
            get => _deliverySelectedItem;
            set
            {

                SetProperty(ref _deliverySelectedItem, value);

                // update the TotalAmount
                caculateTotalAmount();

            }
        }
      
        public ObservableCollection<PRODUCT> Products { get; set; }
        private PRODUCT _productSelectedItem;

        public PRODUCT ProductSelectedItem
        {
            get => _productSelectedItem;
            set
            {

                SetProperty(ref _productSelectedItem, value);

                // update the TotalAmount
                caculateTotalAmount();

            }
        }
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {

                SetProperty(ref _quantity, value);

                // update the TotalAmount
                caculateTotalAmount();
            }
        }

        private int _totalAmount;
        public int TotalAmount
        {
            get => _totalAmount;
            set
            {

                SetProperty(ref _totalAmount, value);
            }
        }

        private void caculateTotalAmount()
        {

            if (String.IsNullOrEmpty(Quantity.ToString()) || Quantity == 0)
            {
                TotalAmount = 0;

                return;
            }

            if (ProductSelectedItem != null && DeliverySelectedItem != null)
            {

                TotalAmount = ProductSelectedItem.productPrice * Quantity + DeliverySelectedItem.deliveryFee;
            }
        }
        FirebaseClient firebaseClient = new FirebaseClient("https://big-system-64b55-default-rtdb.firebaseio.com/");
        public async Task<List<PRODUCT>> GetAllPRODUCTData()
        {
            return
                (await firebaseClient.Child
                (nameof(PRODUCT))
                .OnceAsync<PRODUCT>()).Select(item => new PRODUCT
                {


                    productPrice = item.Object.productPrice,
                    productSize = item.Object.productSize,
                    productType = item.Object.productType,
                    PhotoUrl = item.Object.PhotoUrl,
                    productId = item.Key

                }).ToList();
        }
        public  MyViewModel()
        {

           
            //return (await firebaseClient.Child
            //    (nameof(PRODUCT))
            //    .OnceAsync<PRODUCT>()).Select(item => new PRODUCT
            //    {


            //        productPrice = item.Object.productPrice,
            //        productSize = item.Object.productSize,
            //        productType = item.Object.productType,
            //        PhotoUrl = item.Object.PhotoUrl,
            //        productId = item.Key

            //    }).ToList();


        }
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
