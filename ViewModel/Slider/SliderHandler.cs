using Bindings;
using Model;
using Model.Species;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Slider
{
    public class SliderHandler : INotifyPropertyChanged
    {
        private MainViewModel _mvm { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<BoidSpecies> AllSpecies { get; set; }
        public ObservableCollection<String> AllSpeciesNames { get; set; }
        public ObservableCollection<SliderParameter> Parameters { get; set; }
        protected String _FirstSelected;
        public String FirstSelectedValue
        {
            get { return _FirstSelected; }
            set
            {
                if (_FirstSelected != value)
                {
                    _FirstSelected = value;
                    updateParameters();
                    NotifyPropertyChanged("FirstSelectedValue");
                }
            }
        }

        public SliderHandler(MainViewModel mvm)
        {
            _mvm = mvm;
            AllSpecies = new ObservableCollection<BoidSpecies>(_mvm.Simulation.Species);
            AllSpeciesNames = new ObservableCollection<string>();
            Parameters = new ObservableCollection<SliderParameter>();
            AllSpeciesNames.Add(AllSpecies[0].Name);
            AllSpeciesNames.Add(AllSpecies[1].Name);
            AllSpeciesNames.Add(AllSpecies[2].Name);
        }

        private void updateParameters()
        {
            Parameters.Clear();
            BoidSpecies selected = null;
            List<BoidSpecies> test = (List<BoidSpecies>)_mvm.Simulation.Species;
            foreach (BoidSpecies species in test)
            {
                if (species.Name.Equals(FirstSelectedValue))
                {
                    selected = species;
                }
            }
            var Bindings = selected.Bindings;
            var inbetween = Bindings.Parameters;
            foreach (var data in inbetween)
            {
                if (data is RangedDoubleParameter)
                {
                    var d = (RangedDoubleParameter)data;

                    var paramContent = selected.Bindings.Read(d);

                    Parameters.Add(new SliderParameter(d.Id,paramContent,d.Minimum,d.Maximum));

                }
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
