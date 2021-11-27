using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseSQLite.ViewModels;
using Xamarin.Forms;

namespace XamarinSqlitePerformanceTest.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainViewModel(this.Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing();

            System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Select Start.");

            var persions = App.Database.GetPersons();

            System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Select End.");

            // TODO: ViewModel
            listView.ItemsSource = persions;
        }
    }
}
