using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace DatePickerTest
{
    public class ViewModel : INotifyPropertyChanged
    {
        public DateTime Date { get; set; }

        public Command<DateTime> DateChangedCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public partial class MainPage : ContentPage
    {
        public DateTime Date { get; set; }

        public Command<DateTime> DateChangedCommand { get; set; }
        
        public MainPage()
        {
            InitializeComponent();
            var model = new ViewModel()
            {
                Date = DateTime.UtcNow.Subtract(TimeSpan.FromDays(1)),
                DateChangedCommand = new Command<DateTime>(OnDateChanged)
            };
            BindingContext = model;
        }

        private void OnDateChanged(DateTime newDate)
        {
            Console.WriteLine($"Date was changed to {newDate}");
        }
    }
}