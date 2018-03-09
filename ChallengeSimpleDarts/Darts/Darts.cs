using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        // Properties
        private Random _Rando { get; set; }

        // Class Constructor
        public Dart(Random randomNumber) { _Rando = randomNumber; }
        
        // Method Throw()
        public int[] Throw()
        {
            int[] regionAndMultiplier = new int[2] { 0, 0 };
            regionAndMultiplier[0] = _Rando.Next(0, 21);
            int randoMultiplier = _Rando.Next(0, 21);
            if (randoMultiplier > 1) regionAndMultiplier[1] = 1;
            else if (randoMultiplier == 0) regionAndMultiplier[1] = 2;
            else if (randoMultiplier == 1) regionAndMultiplier[1] = 3;
            return regionAndMultiplier;
        }
    }
}
