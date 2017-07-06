using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattingAverage
{
    class Validator
    {
        static Validator()
        {

        }

        public static int CheckInts(string x)
        {
            int z;
            string y = x;

            while (!Int32.TryParse(y, out z) || z <= 0)
            {
                Console.WriteLine("That is not a valid input, please enter a positive number\n");
                y = Console.ReadLine();
            }

            return z;
        }
    }
}
