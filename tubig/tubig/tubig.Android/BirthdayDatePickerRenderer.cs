using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Graphics;
using Android.Graphics.Drawables;
using tubig.Control;
using tubig.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BirthdayDatePickerControl), typeof(BirthdayDatePickerRenderer))]
namespace tubig.Droid
{
    public class BirthdayDatePickerRenderer : DatePickerRenderer
    {
        public BirthdayDatePickerRenderer(Context context) : base(context)
        {

        }
        EditText editText;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
           //code for placeholder
            if (Control != null)
            {
                Control.Text = "Birth Date";
            }
            //end here

            //code  start here for clearing the data in datepicker input field
            editText = Control as EditText;
            if (e.NewElement != null)  
            {
                BirthdayDatePickerControl bdaydatePickerControl = e.NewElement as BirthdayDatePickerControl;
                 bdaydatePickerControl.ClearRequested += DatePickerControl_ClearRequested;
           
            }
            //end here
          
        }

        public void DatePickerControl_ClearRequested(object sender, EventArgs e)
        {
            //  editText.Text = string.Empty;
            editText.Text = DateTime.Now.ToShortDateString();
        }
    }
}