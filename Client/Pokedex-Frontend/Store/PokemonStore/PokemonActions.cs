using Pokedex_Frontend.Models;

namespace Pokedex_Frontend.Store.PokemonStore;

public record PokemonFetchByNameAction(string Name);
public record PokemonFetchedByNameFailedAction(string Name);
public record PokemonFetchByIdAction(int Id);
public record PokemonFetchedByIdFailedAction(int Id);
public record PokemonFetchedAction(Pokemon Pokemon);