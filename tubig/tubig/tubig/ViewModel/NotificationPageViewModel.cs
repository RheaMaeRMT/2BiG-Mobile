using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
namespace tubig.ViewModel
{
   public  class NotificationPageViewModel: INotifyPropertyChanged
    {
        private string _statusOfOrder;

        public string StatusOfOrder
        {
            get
            {
                return _statusOfOrder;
            }
            set
            {
                _statusOfOrder = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
