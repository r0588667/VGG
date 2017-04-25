using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainViewModel
    {
        public OverViewModel ovm { get; set; }
        public ExitViewModel evm { get; set; }

        public MainViewModel()
        {
            ovm = new OverViewModel();
            evm = new ExitViewModel();
        }
    }

}
