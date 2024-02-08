namespace Pokedex_backend.DTOs
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }

        public PokemonDTO(int id, string name, string image)
        {
            Id = id;
            Name = name;   
            Image = image;
        }
    }
}
