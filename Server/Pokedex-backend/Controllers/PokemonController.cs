using Microsoft.AspNetCore.Mvc;
using Pokedex_backend.Services;

namespace Pokedex_backend.Controllers
{
    [ApiController]
    [Route("api/pokemon/")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPokemonByNameAsync(string name)
        {
            var pokemon = await _pokemonService.GetPokemonByNameAsync(name);
            if (pokemon != null)
            {
                return Ok(pokemon);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPokemonByIdAsync(int id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
            if (pokemon != null)
            {
                return Ok(pokemon);
            }
            else
            {
                return NotFound();
            }
        }
    }
}