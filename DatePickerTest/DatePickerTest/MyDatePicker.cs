using System;
using Xamarin.Forms;

namespace DatePickerTest
{
    public class MyDatePicker : View
    {
        public static readonly BindableProperty DateChangedCommandProperty = BindableProperty.Create(
            propertyName: "DateChangedCommand",
            returnType: typeof(Command),
            declaringType: typeof(MyDatePicker),
            defaultValue: null
        );

        public static readonly BindableProperty DateProperty = BindableProperty.Create("Date",
                                                                                       typeof(DateTime),
                                                                                       typeof(MyDatePicker),
                                                                                       DateTime.MinValue,
                                                                                       BindingMode.TwoWay);

        public Command DateChangedCommand
        {
            get => (Command) GetValue(DateChangedCommandProperty);
            set => SetValue(DateChangedCommandProperty, value);
        }

        public DateTime Date
        {
            get => (DateTime) GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }
    }
}