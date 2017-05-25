using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class ShowOptions : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainViewModel _mvm;
        public ShowOptions(MainViewModel mvm)
        {
            _mvm = mvm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_mvm.Test.WindowIsShown)
            {
                _mvm.Test.WindowIsShown = false;
            }
            else
            {
                _mvm.Test.WindowIsShown = true;
            }
        }
    }
}
