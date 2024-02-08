using System.Text.Json.Serialization;

namespace Pokedex_backend.Models
{
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("sprites")]
        public Sprites? Sprites { get; set; }
    }
}
