using System.ComponentModel;


namespace WPFApp_2
{
    /// <summary>
    ///  Base view model that will fire Property Changed when needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string data;

        /// <summary>
        /// Event fired when any child property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                if (data == value)
                    return;

                data = value;

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Data)));
            }
        }
    }

   
}
