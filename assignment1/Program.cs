/**
 * Authoor: Chad Cunningham
 * Date: ??-Jan-2016
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static bool closeProgram = false;// >Switch for if the program should end.
        static int currentMenu = 1;// >The menu that the user shoud see.

        static CVSProccessor cvs = new CVSProccessor();// >The class to read in a csv.

        static WineItemCollection wineColletion1 = new WineItemCollection(0);// >Will hold a collection that can be searched and manipulated.


        static void Main(string[] args)
        {

            while (closeProgram == false)
            {
                

                switch(currentMenu)
                {
                    case 1:
                        Menu1();
                        break;
                    case 2:
                        // menu2 - cases can be added for a lager program with more menus.
                        break;
                }

            }

        }


        // >The first menu that the user is presented with.
        static void Menu1()
        {
            // >Get the option chosen by the user.
            int menuChoice = StaticUserInterface.DisplayMenu1AndGetChoice();

            switch (menuChoice)
            {
                case 1:
                    // >Load the wine list.
                    bool load = cvs.LoadCVSIntoCollection("../../../datafiles/WineList.csv", wineColletion1);
                    if (load == true)
                    {
                        StaticUserInterface.WriteToScreen("File successfully loaded.");
                        StaticUserInterface.WriteToScreen("");
                    }
                    break;
                case 2:
                    // >If there is something in the array.
                    if (wineColletion1.wineItemArray.Length != 0)
                    {
                        // >Write all of the wines to the screen.
                        wineColletion1.PrintEntireCollection();
                        StaticUserInterface.WriteToScreen("");
                    }
                    else
                    {
                        StaticUserInterface.WriteToScreen("That collection is empty!");
                        StaticUserInterface.WriteToScreen("");
                    }
                    break;
                case 3:
                    // >Promt user.
                    StaticUserInterface.WriteToScreen("Enter an ID");
                    // >Search collection.
                    int location = wineColletion1.SearchById(StaticUserInterface.ReadInputLine());
                    if (location != -1)
                    {
                        // >Write out the located wine.
                        StaticUserInterface.WriteToScreen(wineColletion1.wineItemArray[location].ToString());
                        StaticUserInterface.WriteToScreen("");
                    }
                    else
                    {
                        StaticUserInterface.WriteToScreen("No wine with that ID was found.");
                        StaticUserInterface.WriteToScreen("");
                    }
                    break;
                case 4:
                    if (wineColletion1.wineItemArray.Length > 0)
                    {
                        // >Create a new wine.
                        wineColletion1.wineItemArray[wineColletion1.emptySpot] = new WineItem();

                        StaticUserInterface.WriteToScreen("Add Wine ID");
                        // >Add the id.
                        wineColletion1.wineItemArray[wineColletion1.emptySpot].WineId = StaticUserInterface.ReadInputLine();

                        StaticUserInterface.WriteToScreen("Add Wine Description");
                        // >Add the description.
                        wineColletion1.wineItemArray[wineColletion1.emptySpot].WineDescription = StaticUserInterface.ReadInputLine();

                        StaticUserInterface.WriteToScreen("Add Wine Pack");
                        // >Add the pack.
                        wineColletion1.wineItemArray[wineColletion1.emptySpot].PackType = StaticUserInterface.ReadInputLine();
                    }
                    else
                    {
                        StaticUserInterface.WriteToScreen("That collection is empty!");
                        StaticUserInterface.WriteToScreen("");
                    }
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }





    }
}
