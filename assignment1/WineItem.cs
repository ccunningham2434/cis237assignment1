using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    // >Holds information about a wine.
    public class WineItem
    {
        string _id;// >Identification for the wine.
        string _description;// >A description of the wine.
        string _pack;// >The number in a pack or fluid size.


        // >Properties
        //
        public string WineId
        {
            get { return _id; }
            set { _id = value; }
        }
        public string WineDescription
        {
            get { return _description; }
            set { _description = value; }
        }
        public string PackType
        {
            get { return _pack; }
            set { _pack = value; }
        }


        // >Methods
        //
        public override string ToString()
        {
            return _id + " " + _description + " " +  _pack;
        }


        // >Constructors
        //
        public WineItem()
        {
            _id = string.Empty;
            _description = string.Empty;
            _pack = string.Empty;
        }
        public WineItem(string wineId, string wineDescription, string packType)
        {
            _id = wineId;
            _description = wineDescription;
            _pack = packType;
        }

    }

}