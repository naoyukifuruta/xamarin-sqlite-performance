using System.Threading.Tasks;
using UseSQLite.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinSqlitePerformanceTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _ = Task.Run(async () =>
            {
                await _viewModel.OnAppearing();
            });
        }
    }
}
