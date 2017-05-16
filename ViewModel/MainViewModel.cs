using Cells;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.SubViewModels;
using Model.Species;
using ViewModel.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Mathematics;
using ViewModel.Commands;

namespace ViewModel
{
    public class MainViewModel
    {
        //public Cell<double> Speed { get; set; }

        public Simulation Simulation { get; set; }

        public ICommand Add { get; set; }
        public ICommand Exit { get; set; }
        public ICommand Pause { get; set; }

        public String WindowState { get; set; }

        public event Action ApplicationExit;

        public ITimerService timer { get; set; }


        public MainViewModel()
        {
            WindowState = "Maximized";
            timer = ServiceLocator.Current.GetInstance<ITimerService>();
            timer.Tick += Timer_Tick;
            timer.Start(new TimeSpan(0, 0, 0, 0, 001));
            initializeSimulation();
            Add = new AddBoidCommand(this);
            Exit = new ExitCommand(this);
            Pause = new PauseCommand(this);
        }

        private void initializeSimulation()
        {
            this.Simulation = new Simulation();
            Simulation.Species[0].CreateBoid(new Vector2D(50, 50));
            Simulation.Species[1].CreateBoid(new Vector2D(200, 60));
            Simulation.Species[2].CreateBoid(new Vector2D(300, 200));
        }

        private void Timer_Tick(ITimerService obj)
        {
            Simulation.Update(0.02);
        }



        /*
        public Action speedup()
        {
            var bindings = Simulation.Species.First().Bindings;
            var pars = bindings.Parameters;
            var speed = pars.Where(c => c.Id == "Maximum Speed").Single();
            var rangedDoubleSpeed = speed as RangedDoubleParameter;
            var speedValue = bindings.Read(rangedDoubleSpeed);
            speedValue.Value = Speed.Value;
            return null;
        }
        */
        private class ExitCommand : ICommand
        {
            public ExitCommand(MainViewModel _mvm)
            {
                mvm = _mvm;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                mvm.ApplicationExit?.Invoke();
            }
            private MainViewModel mvm;

        }
    }

}
