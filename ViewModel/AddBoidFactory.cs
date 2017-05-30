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
            if (type.Equals("hunter"))
            {
                inttype = 0;
            }
            else if (type.Equals("prey"))
            {
                inttype = 1;
            }
            else if (type.Equals("peta"))
            {
                inttype = 2;
            }
            else
            {
                throw new IndexOutOfRangeException("AddBoidFactory|HandleBoid bad inttype");
            }
            mvm.Simulation.Species[inttype].CreateBoid(new Mathematics.Vector2D(x,y));
        }
    }
}
