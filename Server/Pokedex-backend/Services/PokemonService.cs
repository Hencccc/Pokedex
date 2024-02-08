using Pokedex_backend.DTOs;
using Pokedex_backend.Models;
using System.Text.Json;

namespace Pokedex_backend.Services
{
    public interface IPokemonService
    {
        Task<PokemonDTO> GetPokemonByNameAsync(string name);
        Task<PokemonDTO> GetPokemonByIdAsync(int number);

    }

    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonDTO> GetPokemonByNameAsync(string name)
        {
            var result = await _httpClient.GetAsync(name);

            if(result.IsSuccessStatusCode)
            {
                var pokemon = JsonSerializer.Deserialize<Pokemon>(await result.Content.ReadAsStreamAsync());
                return new PokemonDTO(pokemon.Id, pokemon.Name, pokemon.Sprites.FrontDefault); 
            }
            else
            {
                //throw new HttpRequestException($"Failed to fetch pokemon with name: {name}");
                return null;
            };
        }

        public async Task<PokemonDTO> GetPokemonByIdAsync(int id)
        {
            var result = await _httpClient.GetAsync(id.ToString());

            if (result.IsSuccessStatusCode)
            {
                var pokemon = JsonSerializer.Deserialize<Pokemon>(await result.Content.ReadAsStreamAsync());
                return new PokemonDTO(pokemon.Id, pokemon.Name, pokemon.Sprites.FrontDefault);
            }
            else
            {
                //throw new HttpRequestException($"Failed to fetch pokemon with name: {name}");
                return null;
            };
        }
    }
}
