using System;
using System.Windows.Input;

namespace WPFApp_2
{
    public class RelayCommand : ICommand
    {

        #region Private Members


        //action to run
        private Action mAction;

        #endregion

        #region Events
        //event thats fired when canExecute object has changed
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion



        //default constructor
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #region command methods

        //relay command can always execute
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
