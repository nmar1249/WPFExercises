using PropertyChanged;
using System.ComponentModel;


namespace WPFApp_2
{
    /// <summary>
    ///  Base view model that will fire Property Changed when needed
    /// </summary>
    [ImplementPropertyChanged]
    class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event fired when any child property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
