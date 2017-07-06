using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattingAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            Dictionary<int, Batter> batters = new Dictionary<int, Batter>();

            while(cont == true)
            {
                // choice and parChoice are declared
                string choice;
                int parChoice;

                // Menu is printed and the user is prompted for input, and that input is validated
                Console.WriteLine("Hello, please make a selection: \n1) Add Batters\n2) Get Batter Info\n3) Quit\n");
                choice = Console.ReadLine();

                while (!Int32.TryParse(choice, out parChoice) && parChoice != 1 && parChoice != 2 && parChoice != 3)
                {
                    Console.WriteLine("Invalid entry. Please make a selection: \n1) Add Batters\n2) Get Batter Info\n3) Quit\n");
                    choice = Console.ReadLine();
                }

                // depending on the user input, a method is ran or the program quits
                if (parChoice == 1)
                {
                    // student builder is called, and the user can populate the dictionary with students
                    batters = BatterBuilder(batters);
                }
                else if (parChoice == 2)
                {
                    // studentChoice is determined based on user input in the getStudentChoice method, and then info for that student is displayed
                    int batterChoice = GetBatterChoice(batters);
                    displayInfo(batters[batterChoice]);
                }
                else
                {
                    // application quits
                    break;
                }
                // cont is checked
                cont = Continue();
            }


        }

        public static Dictionary<int, Batter> BatterBuilder(Dictionary<int, Batter> batters = null)
        {
            // if the dictionary passed in is not null, the stuLeng is set to the size of the dictionary, else it is set to 0
            int battersLeng;
            if (batters != null)
            {
                battersLeng = batters.Count;
            }
            else
            {
                battersLeng = 0;
            }
            string c;
            int cParsed;

            // user provides the number of students that will be created and that input is validated
            Console.WriteLine("How many batters would you like to create? \n");
            c = Console.ReadLine();

            cParsed = Validator.CheckInts(c);

            // a new Student is created every loop and is added to the dictionary at key i
            for (int i = battersLeng; i < battersLeng + cParsed; i++)
            {
                Batter batter = new Batter();
                batters.Add(i, batter);
            }

            return batters;
        }

        public static int GetBatterChoice(Dictionary<int, Batter> batters)
        {
            // if the length of the dictionary provided is 0, the method warns the user and returns out
            if (batters.Count == 0)
            {
                Console.WriteLine("There is no data for any batters. Please add data for batters and then return.\n");
                return 0;
            }

            // count is set to the size of the dictionary, and choice vars are declared
            int count = batters.Count;
            string strChoice;
            int choice;

            // the user is prompted for a choice that corresponds to the student that they want info about, and then the menu is printed by iterating through the 
            // dictionary. User input is validated
            Console.WriteLine("Please select a batter you want info about by typing their number: \n");
            for (int i = 0; i < count; i++)
            {
                string name = batters[i].GetName();
                Console.WriteLine($"{i + 1}) {name}\n");
            }

            strChoice = Console.ReadLine();

            while (!Int32.TryParse(strChoice, out choice) || choice < 1 || choice > count)
            {
                Console.WriteLine($"Invalid entry. Please enter a number between 1 and {count} to get info about the corresponding batter.");
                strChoice = Console.ReadLine();
            }

            // choice - 1 is returned, because 1 is added to make the student list non-zero indexed
            return choice - 1;
        }

        public static void displayInfo(Batter batter)
        {

            // data is retrieved from the Batter object, formatted and printed
            double average = batter.BattingAverage();
            double slugging = batter.SluggingAverage();
            string name = batter.GetName();

            

            Console.WriteLine($"{name}'s averade is {average} and their slugging average is {slugging}");

            return;
        }

        public static bool Continue()
        {
            // user is prompted for confirmation to continue or quit
            string answer;
            bool cont;

            Console.WriteLine("Continue?\ny/n");
            answer = Console.ReadLine();

            while (answer != "y" && answer != "Y" && answer != "n" && answer != "N")
            {
                Console.WriteLine("Invalid entry.\nPlease enter y to continue or n to quit.\n");
                answer = Console.ReadLine();
            }

            if (answer == "n" || answer == "N")
            {
                cont = false;
                return cont;
            }
            else
            {
                cont = true;
                return cont;
            }
        }

    }
}
