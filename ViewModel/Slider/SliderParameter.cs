using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Slider
{
    public class SliderParameter
    {
        public Cell<Double> CurrentValue { get; set; }
        public Double Minimum { get; set; }
        public Double Maximum { get; set; }
        public String ParameterID { get; set; }
        public SliderParameter(String ID,Cell<Double> CurrentValue, Double Minimum, Double Maximum)
        {
            this.ParameterID = ID;
            this.CurrentValue = CurrentValue;
            this.Minimum = Minimum;
            this.Maximum = Maximum;
        }
    }
}
