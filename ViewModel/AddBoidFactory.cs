using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class AddBoidFactory
    {

        public static void handleBoid(MainViewModel mvm, String type,int x,int y)
        {
            var inttype = 0;
            if (type.Equals("Hunter"))
            {
                inttype = 0;
            }
            else if (type.Equals("Prey"))
            {
                inttype = 1;
            }
            else if (type.Equals("PETA"))
            {
                inttype = 2;
            }
            else
            {
                // throw new Exception("Invalid Boid");
            }
            mvm.Simulation.Species[inttype].CreateBoid(new Mathematics.Vector2D(x,y));
        }
    }
}
