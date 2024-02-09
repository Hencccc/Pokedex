using Fluxor;
using Pokedex_Frontend.Models;
using System.Net.Http.Json;

namespace Pokedex_Frontend.Store.PokemonStore;

public class PokemonEffects
{
    private readonly HttpClient _httpClient;
    private readonly string BASE_URL = "https://localhost:7083/api/pokemon/";

    public PokemonEffects(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [EffectMethod]
    public async Task FetchPokemonByName(PokemonFetchByNameAction action, IDispatcher dispatcher)
    {
        var result = await _httpClient.GetAsync(BASE_URL + action.Name);

        if(result.IsSuccessStatusCode)
        {
            var pokemon = result.Content.ReadFromJsonAsync<Pokemon>().Result!;
            dispatcher.Dispatch(new PokemonFetchedAction(pokemon));
        }
        else
        {
            dispatcher.Dispatch(new PokemonFetchedByNameFailedAction(action.Name));
        }
    }

    [EffectMethod]
    public async Task FetchPokemonById(PokemonFetchByIdAction action, IDispatcher dispatcher)
    {
        var result = await _httpClient.GetAsync(BASE_URL + action.Id);

        if (result.IsSuccessStatusCode)
        {
            var pokemon = result.Content.ReadFromJsonAsync<Pokemon>().Result!;
            dispatcher.Dispatch(new PokemonFetchedAction(pokemon));
        }
        else
        {
            dispatcher.Dispatch(new PokemonFetchedByIdFailedAction(action.Id));
        }
    }
}

