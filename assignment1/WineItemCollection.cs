using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    // >Holds a collection of WineItems.
    public class WineItemCollection
    {
        public WineItem[] wineItemArray;
        public int emptySpot;


        // >Methods
        //
        // >Search the array for a wineId that matches the input. Returns the element in which a match was found or -1 if there was no match.
        public int SearchById(string id)
        {
            bool idFound = false;// >If the wine id was found or not.
            int arrayLocation = -1;// >The array element where a match was found. -1 if there was no match.

            int count = 0;// >Counts what array element the search is on.

            // >If the arry is not empty.
            if (wineItemArray.Length != 0)
            {
                // >Continue searching until the id is found or the end of the array is reached.
                while (idFound == false && count < wineItemArray.Length)
                {
                    if (wineItemArray[count] != null)
                    {
                        if (wineItemArray[count].WineId == id)
                        {
                            idFound = true;
                            arrayLocation = count;
                        }
                    }

                    // >Increase the counter.
                    count += 1;
                }
            }
            return arrayLocation;
        }

        // >Write all of the wines to the screen.
        public void PrintEntireCollection()
        {
            for (int i=0; i < wineItemArray.Length; i++)
            {
                if (wineItemArray[i] != null)
                {
                    StaticUserInterface.WriteToScreen(wineItemArray[i].ToString());
                }
            }
        }


        // >Constructors
        //
        public WineItemCollection(int collectionSize)
        {
            wineItemArray = new WineItem[collectionSize];
        }

    }
}
