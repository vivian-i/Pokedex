using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace PokemonMauiApp.Model
{
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public double Latitude { get; init; }
        public double Longitude { get; init; } 
        //Sprites contains pokemon images
        public Sprites Sprites { get; set; }
        //Stat contains list of pokemon stats. ex: the name of the stats(e.g. 'hp', 'attack', etc) and its value. 
        public List<Stat> Stats { get; set; }
        public Species Species { get; set; }
        //Type contains the pokemon types. ex: water, fire, etc
        private List<Type> _types;
        public List<Type> Types
        {
            get => _types;
            set
            {
                _types = value;
                Color = DetermineColor();
            }
        }
        //pokemon color based on types
        public Color Color { get; private set; }
        //pokemon name
        private string _name;
        public string Name
        {
            get => _name;
            init
            {
                _name = CapitalizeName(value);
            }
        }

        //default constructor
        public Pokemon()
        {
            Latitude = GenerateRandomCoordinates(516400146, 630304598, "18.");
            Longitude = GenerateRandomCoordinates(224464416, 341194152, "-72.");
        }

        //capitalize first letter
        private string CapitalizeName(string name)
        {
            string res = "";
            //capitalize first letter
            if (string.IsNullOrEmpty(name))
            {
                res = name;
            }
            else
            {
                res = char.ToUpper(name[0]) + name.Substring(1);
            }

            return res;
        }

        //determine pokemon color from Types
        private Color DetermineColor()
        {
            Color color = new Color();

            if (_types != null && _types.Count > 0)
            {
                color = _types[0].Type2.Color;
            }

            return color;
        }

        //latitude and longitude coordinates
        private double GenerateRandomCoordinates(int min, int max, string wholeNumCoords)
        {
            Random r = new Random();
            //lat: 18.51640014679267 - 18.630304598192915
            //long: -72.34119415283203 - -72.2244644165039
            string decimalCoords = r.Next(min, max).ToString();
            double coords = Convert.ToDouble(wholeNumCoords + decimalCoords);

            return coords;
        }

    }
}
