using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public static class Dart
    {
        /*
        // Properties
        public int RandomRegionNumber { get; set; }
        public int RandomRingNumber { get; set; }

        // Class Constructor
        public Dart(int _randoRegion, int _randoRing)
        {
            int RandomRegionNumber = _randoRegion;
            int RandomRingNumber = _randoRing;
        }
        */
        
        // Method Throw()
        public static int[] Throw(int _randoRegion, int _randoRing)
        {
            int[] regionAndMultiplier = new int[2] { 0, 0 };
            regionAndMultiplier[0] = _randoRegion;
            if (_randoRing > 1) regionAndMultiplier[1] = 1;
            else if (_randoRing == 0) regionAndMultiplier[1] = 2;
            else if (_randoRing == 1) regionAndMultiplier[1] = 3;
            return regionAndMultiplier;
        }
        
    }
}
