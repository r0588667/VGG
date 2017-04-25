using Mathematics;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class OverViewModel : INotifyPropertyChanged
    {
        public OverViewModel()
        {
            timer = ServiceLocator.Current.GetInstance<ITimerService>();
            timer.Tick += Timer_Tick;
            timer.Start(new TimeSpan(0, 0, 0,0,0900));
            this.Simulation = new Simulation();
            this.Simulation.Species[0].CreateBoid(new Vector2D(50, 50));
            this.Simulation.Species[1].CreateBoid(new Vector2D(60, 60));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Simulation Simulation { get; }

        private void Timer_Tick(ITimerService obj)
        {
                Simulation.Update(0.2);
        }
        private ITimerService timer;
    }
}

