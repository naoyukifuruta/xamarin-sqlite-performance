using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinSqlitePerformanceTest;
using XamarinSqlitePerformanceTest.Databases;

namespace UseSQLite.ViewModels
{
    public class MainViewModel
    {
        private static Random _random = new Random();

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
            System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Insert Start.");

            var insertPersions = new List<Person>();

            for (var i = 1; i <= 1000; i++)
            {
                var p = new Person()
                {
                    Name = Guid.NewGuid().ToString(),
                    Age = _random.Next(10, 100),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                insertPersions.Add(p);
            }

            App.Database.SavePersons(insertPersions);


            System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Insert End.");
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
