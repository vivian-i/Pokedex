using System.Text.Json.Serialization;

namespace PokemonMauiApp.Model
{
    public class Stat
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }//BaseStat is the stat value
        public int Effort { get; set; }
        [JsonPropertyName("stat")]
        public Stat2 Stat2 { get; set; }//Stat2 contains the stat's name, e.g. 'hp', 'attack', 'defense', etc.
    }
}
