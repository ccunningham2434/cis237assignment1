using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    // >Handles reading cvs files and filling WineItemCollections.
    public class CVSProccessor
    {
        StreamReader streamReader;// >Stream reader to read from a file.
        string _filePath;// >The path where the file is located.
        int _fileLineCount;// >The number of lines in the file.
        bool _hasFileBeenRead;// >Used to ensure that the file an only be used once.


        // >Properties
        //
        public string FilePath
        {
            get { return _filePath; }
        }
        public int FileLineCount
        {
            get { return _fileLineCount; }
        }
        public bool HasFileBeenRead
        {
            get { return _hasFileBeenRead; }
        }


        // >Methods
        //
        // >Try to read in a CVS file and add the data to a collection.
        public bool LoadCVSIntoCollection(string filePath, WineItemCollection collection)
        {
            try
            {
                // >Assign the file.
                streamReader = new StreamReader(filePath);
                // >Change the file path to the new one.
                _filePath = filePath;
                // >Find the number of lines in the new file.
                _fileLineCount = File.ReadLines(_filePath).Count();

                // >Make the collections array have the same amount of elements as lines in the file. add 400 to be able to add wines.
                collection.wineItemArray = new WineItem[(_fileLineCount + 400)];

                string line;// >String to hold what is read in.

                int count = 0;// >The current file line number.
                while (!streamReader.EndOfStream)
                {
                    // >Read a line.
                    line = streamReader.ReadLine();
                    // >Split the data.
                    string[] temp = line.Split(',');

                    // >Create an WineItem.
                    collection.wineItemArray[count] = new WineItem();

                    // >Set data for the wine item at the current collection element.
                    collection.wineItemArray[count].WineId = temp[0];
                    collection.wineItemArray[count].WineDescription = temp[1];
                    collection.wineItemArray[count].PackType = temp[2];

                    // >Increase the count.
                    count += 1;
                }
                // >Mark the next available position.
                collection.emptySpot = count;
                // >Mark the file as have being read.
                _hasFileBeenRead = true;
                // >If successful return true.
                return true;
            }
            catch (Exception e)
            {
                StaticUserInterface.WriteToScreen("*******************  !!!!!!!!!!!!!  *******************");
                StaticUserInterface.WriteToScreen("File does not exist or is not in a CVS readable format!");
                StaticUserInterface.WriteToScreen(e.ToString());
                StaticUserInterface.WriteToScreen("*******************  !!!!!!!!!!!!!  *******************");
                return false;
            }
            finally
            {
                if (streamReader != null)
                {
                    // >Close the file.
                    streamReader.Close();
                }
            }

        }


        // >Constructors
        //
        public CVSProccessor()
        {
            streamReader = null;
            _filePath = null;
             _fileLineCount = 0;
            _hasFileBeenRead = false;
        }

    }
}
