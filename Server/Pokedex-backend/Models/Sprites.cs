using System.Text.Json.Serialization;

namespace Pokedex_backend.Models
{
    public class Sprites
    {
        [JsonPropertyName("front_default")]
        public string? FrontDefault { get; set; }
    }
}
