using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinSqlitePerformanceTest;
using XamarinSqlitePerformanceTest.Databases;

namespace UseSQLite.ViewModels
{
    public class MainViewModel
    {
        public ICommand AddCommand { get; set; }

        //public ICommand ListTappedCommand { get; set; }

        private INavigation _navigation;

        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;

            AddCommand = new Command(async () => await Add());

            //ListTappedCommand = new Command<Note>(async (note) => await TapListViewItem(note));
        }

        public async Task OnAppearing()
        {
            var p = new Person()
            {
                Name = "Test01",
                Age = 20,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await App.Database.SavePersonAsync(p);
        }

        private async Task Add()
        {
            //await _navigation.PushAsync(new NoteEntryPage
            //{
            //    BindingContext = new Note()
            //});
        }

        //private async Task TapListViewItem(Note note)
        //{
        //    await _navigation.PushAsync(new NoteEntryPage
        //    {
        //        BindingContext = note
        //    });
        //}
    }
}
