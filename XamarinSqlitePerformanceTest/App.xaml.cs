using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
                    database = new SqliteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "test.db3"));
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
