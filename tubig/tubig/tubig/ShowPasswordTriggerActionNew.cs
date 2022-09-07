using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;

namespace tubig
{
    class ShowPasswordTriggerActionNew : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        public string ShowIcon { get; set; }
        public string HideIcon { get; set; }

        bool _hidepassword = true;

        public bool Hidepassword { get=>_hidepassword; set
            {
                if (_hidepassword != value)
                {
                    _hidepassword = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hidepassword)));
                }

            }
        
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected override void Invoke(ImageButton sender)
        {
            sender.Source = Hidepassword ? ShowIcon : HideIcon;
            Hidepassword = !Hidepassword;
        }
    }
}
