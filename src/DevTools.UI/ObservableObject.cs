using System.ComponentModel;

namespace DevTools.UI
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) => this.PropertyChanged?.Invoke(this, e);

        protected void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
