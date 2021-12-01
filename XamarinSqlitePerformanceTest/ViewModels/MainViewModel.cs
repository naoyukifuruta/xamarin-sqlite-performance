using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;
using XamarinSqlitePerformanceTest;
using XamarinSqlitePerformanceTest.Databases;
using XamarinSqlitePerformanceTest.Databases.Entities;
using XamarinSqlitePerformanceTest.ViewModels;

namespace UseSQLite.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private static Random _random = new Random();

        private INavigation _navigation;

        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        private string _count;
        public string Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public async Task OnAppearing()
        {
            using (UserDialogs.Instance.Loading(""))
            {
                using (var db = DatabaseAccessorFactory.Create())
                {
                    db.DeletePersons();

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

                    db.SavePersons(insertPersions);

                    System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Insert End.");

                    System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Select Start.");

                    var persons = db.GetPersons();

                    System.Diagnostics.Debug.WriteLine($"[{DateTime.Now}] Select End.");

                    this.Count = $"{persons.Count.ToString()} 件";

                    var temps = new ObservableCollection<Person>();
                    foreach (var p in persons)
                    {
                        temps.Add(p);
                    }
                    this.Persons = temps;
                }
            }
        }
    }
}
