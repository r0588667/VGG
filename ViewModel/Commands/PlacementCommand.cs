using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class PlacementCommand : ICommand
    {
        private int x { get; set;}
        private int y { get; set; }
        private MainViewModel _mvm;

        public PlacementCommand(MainViewModel mvm)
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
            _mvm.setXAndY();
            _mvm.isRandomPlacement = _mvm.isRandomPlacement ? false : true;
        }
    }
}
