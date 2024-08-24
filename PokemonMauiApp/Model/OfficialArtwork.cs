using System.Text.Json.Serialization;

namespace PokemonMauiApp.Model
{
    public class OfficialArtwork
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }
}