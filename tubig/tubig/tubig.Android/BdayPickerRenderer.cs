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
using Xamarin.Forms;
using tubig.Control;
using tubig.Droid;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(NullableDatePicker), typeof(BdayPickerRenderer))]

namespace tubig.Droid
{
    public class BdayPickerRenderer : ViewRenderer<NullableDatePicker, EditText>
    {
        public BdayPickerRenderer(Context context) : base(context)
        {

        }

        DatePickerDialog _dialog;
        protected override void OnElementChanged(ElementChangedEventArgs<NullableDatePicker> e)
        {
            base.OnElementChanged(e);
            this.SetNativeControl(new Android.Widget.EditText(Forms.Context));

            if (Control == null || e.NewElement == null)

                return;
            this.Control.Click += OnPickerClick;

            this.Control.Text = Element.Date.ToString(Element.Format);
            this.Control.KeyListener = null;

            this.Control.FocusChange += OnPickerFocusChange;

            this.Control.Enabled = Element.IsEnabled;

            Element.ClearRequested += Element_ClearRequested;

        }
        private void Element_ClearRequested(object sender, EventArgs e)
        {


            this.Element.CleanDate();
            Control.Text = this.Element.Format;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)

        {

            base.OnElementPropertyChanged(sender, e);



            if (e.PropertyName == Xamarin.Forms.DatePicker.DateProperty.PropertyName || e.PropertyName == Xamarin.Forms.DatePicker.FormatProperty.PropertyName)

                SetDate(Element.Date);

        }
        void OnPickerFocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
        {

            if (e.HasFocus)
            {
                ShowDatePicker();
            }

        }
        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                this.Control.Click -= OnPickerClick;

                this.Control.FocusChange -= OnPickerFocusChange;

                if (_dialog != null)

                {

                    _dialog.Hide();

                    _dialog.Dispose();

                    _dialog = null;

                }

            }



            base.Dispose(disposing);

        }
        void OnPickerClick(object sender, EventArgs e)

        {

            ShowDatePicker();

        }

        void SetDate(DateTime date)

        {
            //ToString(Element.Format)
            this.Control.Text = date.ToShortDateString();

            Element.Date = date;

        }
        private void ShowDatePicker()

        {

            CreateDatePickerDialog(this.Element.Date.Year, this.Element.Date.Month - 1, this.Element.Date.Day);

            _dialog.Show();

        }
        void CreateDatePickerDialog(int year, int month, int day)

        {
            NullableDatePicker view = Element;

            _dialog = new DatePickerDialog(Context, (o, e) =>

            {

                view.Date = e.Date;

                ((IElementController)view).SetValueFromRenderer(VisualElement.IsFocusedProperty, false);

                Control.ClearFocus();



                _dialog = null;

            }, year, month, day);
            _dialog.SetButton("OK", (sender, e) =>

            {

                SetDate(_dialog.DatePicker.DateTime);

                this.Element.Format = this.Element._originalFormat;

                this.Element.AssignValue();

            });

            _dialog.SetButton2("cancel", (sender, e) =>

            {

                //   this.Element.CleanDate();

                //   Control.Text = this.Element.Format;

                _dialog.Dismiss();

            });
        }
    }

}