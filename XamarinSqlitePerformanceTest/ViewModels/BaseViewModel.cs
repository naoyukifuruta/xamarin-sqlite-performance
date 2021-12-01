using System.ComponentModel;

namespace XamarinSqlitePerformanceTest.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public string PageTitle { get; set; }

        public BaseViewModel() { }

        public BaseViewModel(string pageTitle) : this()
        {
            PageTitle = pageTitle;
        }

        #region INotifyPropertyChangedの実装

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChangedの実装
    }
}
