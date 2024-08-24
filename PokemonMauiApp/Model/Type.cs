using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonMauiApp.Model
{
    public class Type
    {
        public int Slot { get; set; }
        [JsonPropertyName("type")]
        public Type2 Type2 { get; set; }
    }
}
