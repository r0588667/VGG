using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class PauseCommand : ICommand
    {
        private Boolean paused = false;
        private MainViewModel mvm;
        public event EventHandler CanExecuteChanged;

        public PauseCommand(MainViewModel _mvm)
        {
            mvm = _mvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!paused)
            {
                mvm.timer.Start(new TimeSpan(10, 0, 0, 0, 0));
            }
            else
            {
                mvm.timer.Start(new TimeSpan(0, 0, 0, 0, 001));
            }

            paused = paused ? false : true;
        }

    }
}
