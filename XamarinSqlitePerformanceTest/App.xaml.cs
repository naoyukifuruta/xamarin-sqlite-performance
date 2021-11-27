using Xamarin.Forms;
using XamarinSqlitePerformanceTest.Databases;
using XamarinSqlitePerformanceTest.Views;

namespace XamarinSqlitePerformanceTest
{
    public partial class App : Application
    {
        static SqliteDatabase database;

        public static SqliteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SqliteDatabase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
