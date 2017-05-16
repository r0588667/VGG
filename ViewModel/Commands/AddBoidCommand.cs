using Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.SubViewModels
{
    public class AddBoidCommand : ICommand
    {
            public MainViewModel _mvm;
            public AddBoidCommand(MainViewModel mvm)
            {
                _mvm = mvm;
            }
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                AddBoidFactory.handleBoid(_mvm, (string) parameter);
            }
        }
}
