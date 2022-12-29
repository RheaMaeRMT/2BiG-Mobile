using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace tubig.Control
{
    public class BirthdayDatePickerControl : DatePicker
    {
        public event EventHandler ClearRequested;
        
        // for my placeholder "birthdate"
            public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(BirthdayDatePickerControl), defaultValue: default(string));
            public string Placeholder { get; set; }
        
        //function to clear data of my datepicker input
        public void clear()
        {
            if (ClearRequested != null)
            {
                ClearRequested(this, EventArgs.Empty);
            }
        }


        public string _originalFormat = null;

    }
}
