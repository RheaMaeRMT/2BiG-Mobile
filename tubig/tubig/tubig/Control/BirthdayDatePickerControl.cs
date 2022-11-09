using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace tubig.Control
{
    public class BirthdayDatePickerControl : DatePicker
    {
       
        
            public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(BirthdayDatePickerControl), defaultValue: default(string));
            public string Placeholder { get; set; }
        
    }
}
