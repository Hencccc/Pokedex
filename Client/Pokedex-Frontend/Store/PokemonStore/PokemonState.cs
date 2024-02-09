using Fluxor;
using Pokedex_Frontend.Models;

namespace Pokedex_Frontend.Store.PokemonStore;
public record PokemonState
{
    public Pokemon Pokemon { get; init; }
}

public class PokemonFeature : Feature<PokemonState>
{
    public override string GetName() => "Pokemon";

    protected override PokemonState GetInitialState()
    {
        return new PokemonState
        {
            Pokemon = null
        };
    }
}