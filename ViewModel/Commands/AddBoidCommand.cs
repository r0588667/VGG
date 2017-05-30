using System;
using System.Windows.Input;

namespace ViewModel.SubViewModels
{
    public class AddBoidCommand : ICommand
    {
            private int x { get; set; }
            private int y { get; set; }
        public MainViewModel _mvm;
            public AddBoidCommand(MainViewModel mvm)
            {
                _mvm = mvm;
                this.x = x;
                this.y = y;
            }
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                AddBoidFactory.handleBoid(_mvm, (string) parameter,_mvm.X,_mvm.Y);
                _mvm.setXAndY();
            }
        }
}
