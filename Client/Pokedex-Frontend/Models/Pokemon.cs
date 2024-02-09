using System.Text.Json.Serialization;

namespace Pokedex_Frontend.Models;
public class Pokemon
{
    [JsonPropertyName("id")]
    public int Id { get; set; } = 0;
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;

    public Pokemon(int id, string name, string image)
    {
        Id = id;
        Name = name;  
        Image = image;
    }
}
