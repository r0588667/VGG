﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ExitViewModel
    {
        public ExitViewModel()
        {
            Exit = new ExitCommand(this);
            Closing = new ClosingCommand(this);
        }
        public ICommand Exit { get;private set;}
        public ICommand Closing { get; private set;}

        public event Action ApplicationExit;

        private class ClosingCommand : ICommand
        {
            public ClosingCommand(ExitViewModel exitVm)
            {
                evm = exitVm;
            }
            public event EventHandler CanExecuteChanged;
            private ExitViewModel evm;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                evm.ApplicationExit?.Invoke();
            }
        }

        private class ExitCommand : ICommand
        {
            public ExitCommand(ExitViewModel exitVm)
            {
                evm = exitVm;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                evm.ApplicationExit?.Invoke();
            }
            private ExitViewModel evm;
        }
    }
}