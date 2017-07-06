using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattingAverage
{
    class Batter
    {
        private string name;
        private int bats;
        private int bases;
        private int onBases;

        public Batter()
        {
            name = SetName();
            bats = SetBats();
            bases = SetBases();
            onBases = SetOnBase();
        }

        public string SetName()
        {
            string name;

            Console.WriteLine("What is your batters name? ");
            name = Console.ReadLine();

            return name;
        }

        public int SetBats()
        {
            string x;
            int y;
            Console.WriteLine("How many at bats has the player had? \n");
            x = Console.ReadLine();

            y = Validator.CheckInts(x);

            return y;
        }

        public int SetBases()
        {
            string x;
            int y;
            Console.WriteLine("How many bases has the player gotten on? \n");
            x = Console.ReadLine();

            y = Validator.CheckInts(x);

            return y;
        }

        public int SetOnBase()
        {
            string x;
            int y;
            Console.WriteLine("How many times did the player at least get on base? \n");
            x = Console.ReadLine();

            y = Validator.CheckInts(x);

            return y;      
        }
        
        public double BattingAverage()
        {
            double x = bats;
            double y = onBases;

            double z = Math.Round((y / x), 3);

            return z;
        }

        public double SluggingAverage()
        {
            double x = bats;
            double y = bases;

            double z = Math.Round((y / x), 3);

            return z;
        }

        public string GetName()
        {
            return name;
        }
    }
}
