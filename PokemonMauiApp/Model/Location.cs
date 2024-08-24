using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMauiApp.Model
{
    public class Location
    {
        public double Latitude { get; } = GenerateRandomCoordinates(516400146, 630304598, "18.");
        public double Longitude => GenerateRandomCoordinates(224464416, 341194152, "-72.");

        private static double GenerateRandomCoordinates(int min, int max, string wholeNumCoords)
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
