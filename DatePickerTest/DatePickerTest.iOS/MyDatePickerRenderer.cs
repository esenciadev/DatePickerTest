using System;
using CoreGraphics;
using DatePickerTest;
using DatePickerTest.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyDatePicker), typeof(MyDatePickerRenderer))]
namespace DatePickerTest.iOS
{
    public class MyDatePickerRenderer : ViewRenderer<MyDatePicker, UIDatePicker>
    {
        private UIDatePicker _datePicker;

        protected override void OnElementChanged(ElementChangedEventArgs<MyDatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                _datePicker.ValueChanged -= DatePickerOnValueChanged;
            }

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    _datePicker = new UIDatePicker(new CGRect(
                        e.NewElement.Bounds.X,
                        e.NewElement.Bounds.Y,
                        e.NewElement.Bounds.Width,
                        e.NewElement.Bounds.Height
                     ));
                    _datePicker.Mode = UIDatePickerMode.DateAndTime;
                    _datePicker.Date = (NSDate) Element.Date;
                    _datePicker.MaximumDate = (NSDate) Element.Date.AddDays(1);
                    _datePicker.MinimumDate = (NSDate) Element.Date.Subtract(TimeSpan.FromDays(5));
                    _datePicker.MinuteInterval = 1;

                    SetNativeControl(_datePicker);
                }

                _datePicker.ValueChanged += DatePickerOnValueChanged;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _datePicker.ValueChanged -= DatePickerOnValueChanged;
            }
        }

        private void DatePickerOnValueChanged(object sender, EventArgs e)
        {
            var date = (DateTime) _datePicker.Date;

            Element.Date = date;
            Element.DateChangedCommand?.Execute(date);
        }
    }
}