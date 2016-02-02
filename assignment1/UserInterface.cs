using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    // >A 'middleman' class so that the program can still call the same methods, only the ui would need changes.
    public static class StaticUserInterface
    {
        // >Write the input string to the console.
        public static void WriteToScreen(string input)
        {
            Console.WriteLine(input);
        }

        // >Read a line from the console.
        public static string ReadInputLine()
        {
            // >Get the input.
            string input = Console.ReadLine();

            return input;
        }


        // >Checks if a string can be parsed, and if it is within a range.
        static bool CheckIfValidSelection(string inputString, int minRange, int maxRange)
        {
            int parsedNum = -1;

            // >Check if input can be parsed.
                // >If input can not be parsed then return false.
                if (int.TryParse(inputString, out parsedNum))
                {
                    // >Check if the parsed number is a menu option.
                    // >If the number is a valid selection then return true. If it is not then false is returned.
                    if (minRange >= 1 && maxRange <= 5)
                    {
                        return true;
                    }
                }

            return false;
        }


        // >Dislpays the menu and returns a valid option chosen by the user.
        public static int DisplayMenu1AndGetChoice()
        {
            int menuOption = -1;// >The menu option chosen by user. -1 is for initialization.
            bool goodInput = false;// >If the input is good or not. Start with bad input.

            // >Show the menu.
            DisplayMenu1();
            // >Get the user input.
            string input = Console.ReadLine();


            // >If the input is valid, set 'goodInput' to true.
            if (CheckIfValidSelection(input, 1, 5))
            {
                goodInput = true;
                menuOption = int.Parse(input);
            }

            // >Continue asking for input until a valid number is entered.
            while (goodInput == false)
            {
                Console.WriteLine("That is not a valid Selection");
                Console.WriteLine("");
                // >Display the menu.
                DisplayMenu1();
                // >Get the user input.
                input = Console.ReadLine();

                // >If the input is valid, set 'goodInput' to true.
                if (CheckIfValidSelection(input, 1, 5))
                {
                    goodInput = true;
                    menuOption = int.Parse(input);
                }
            }

            // >Return the selected menu option.
            return menuOption;
        }

        // >Writes the menu to the console.
        static void DisplayMenu1()
        {
            Console.WriteLine("1. Load the wine list");
            Console.WriteLine("2. View the list");
            Console.WriteLine("3. Search by wine ID");
            Console.WriteLine("4. Add a wine to the list");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");
        }











    }

}
// ../../datafiles/file

