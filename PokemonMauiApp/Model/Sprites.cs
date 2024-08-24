using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonMauiApp.Model
{
    public class Sprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
        public Other Other { get; set; }
    }
}
