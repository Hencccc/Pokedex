using Fluxor;

namespace Pokedex_Frontend.Store.PokemonStore;
public static class PokemonReducers
{
    [ReducerMethod]
    public static PokemonState OnPokemonFetchedAction(PokemonState state, PokemonFetchedAction action)
    {
        Console.WriteLine("reducer" + action.Pokemon.Name);
        return state with
        {
            Pokemon = action.Pokemon
        };
    }
}