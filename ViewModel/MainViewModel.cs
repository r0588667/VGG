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
using ViewModel.Slider;
using System.ComponentModel;
using View;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public Simulation Simulation { get; set; }

        public ICommand Add { get; set; }
        public ICommand Exit { get; set; }
        public ICommand Pause { get; set; }
        public ICommand ChangePlacement { get; set; }


        public BooleanPropertyChanged Test { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool isRandomPlacement { get; set; }
        public event Action ApplicationExit;
        public event PropertyChangedEventHandler PropertyChanged;

        public ITimerService timer { get; set; }
        public SliderHandler Sliders { get; set; }

        public MainViewModel()
        {
            timer = ServiceLocator.Current.GetInstance<ITimerService>();
            timer.Tick += Timer_Tick;
            timer.Start(new TimeSpan(0, 0, 0, 0, 001));
            initializeSimulation();
            X = 400;
            Y = 400;
            isRandomPlacement = false;
            this.setXAndY();
            Test = new BooleanPropertyChanged(true);
            Add = new AddBoidCommand(this);
            Exit = new ExitCommand(this);
            Pause = new PauseCommand(this);
            Sliders = new SliderHandler(this);
            ChangePlacement = new PlacementCommand(this);
        }

        protected void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                string test = name;
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
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

        public void setXAndY()
        {
            if (isRandomPlacement)
            {
                Random randomNum = new Random();
                X = randomNum.Next(1, 800);
                Y = randomNum.Next(1, 900);
            }
            else
            {
                X = 400;
                Y = 400;
            }
        }
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
