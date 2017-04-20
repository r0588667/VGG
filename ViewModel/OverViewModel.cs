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
            this.Simulation = new Simulation();
            this.Simulation.Species[0].CreateBoid(new Vector2D(50, 50));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Simulation Simulation { get; }

        public void updateSimulation()
        {
            Simulation.Update(0.2);
        }
    }
}

