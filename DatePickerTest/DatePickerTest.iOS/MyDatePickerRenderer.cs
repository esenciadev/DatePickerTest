using System;
using System.ComponentModel;
using CoreGraphics;
using DatePickerTest;
using DatePickerTest.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("DatePickerTest")]
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
                    _datePicker = new UIDatePicker(new CGRect(e.NewElement.Bounds.X,
                                                              e.NewElement.Bounds.Y,
                                                              320,
                                                              216));
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
            if (disposing && _datePicker != null)
            {
                if (Device.IsInvokeRequired)
                {
                    Device.BeginInvokeOnMainThread(() => { _datePicker.ValueChanged -= DatePickerOnValueChanged; });
                }
                else
                {
                    _datePicker.ValueChanged -= DatePickerOnValueChanged;
                }
            }
        }

        private void DatePickerOnValueChanged(object sender, EventArgs e)
        {
            var date = (DateTime) _datePicker.Date;

            if (Device.IsInvokeRequired)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Element.Date = date;
                    Element.DateChangedCommand?.Execute(date);
                });
            }
            else
            {
                Element.Date = date;
                Element.DateChangedCommand?.Execute(date);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}