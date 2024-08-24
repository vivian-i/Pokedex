using System.Text.Json.Serialization;

namespace PokemonMauiApp.Model
{
    public class Other
    {
        public Home Home { get; set; }

        [JsonPropertyName("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }
}