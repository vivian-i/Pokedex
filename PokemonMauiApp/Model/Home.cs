using System.Text.Json.Serialization;

namespace PokemonMauiApp.Model
{
    public class Home
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }
}