using Blazored.Toast.Services;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Pokedex_Frontend.Store.PokemonStore;

namespace Pokedex_Frontend.Pages;

public partial class Index
{
    private string _input { get; set; } = string.Empty;
    private string _searchValue { get; set; } = string.Empty;

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    [Inject]
    private IState<PokemonState> PokemonState { get; set; }

    [Inject]
    private IToastService ToastService { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SubscribeToAction<PokemonFetchedFailedAction>(ShowErrorToast);
    }

    private void DispatchFetchPokemon()
    {
        _searchValue = _input;
        Dispatcher.Dispatch(int.TryParse(_input, out int n)
            ? new PokemonFetchByIdAction(n)
            : new PokemonFetchByNameAction(_input));

        _input = string.Empty;
    }

    private void ShowErrorToast(PokemonFetchedFailedAction action)
    {
        Console.WriteLine("Error: " + _searchValue);
        ToastService.ShowError($"Pokemon with search string: {_searchValue} could not be found. Please try again.");
        _searchValue = string.Empty;
    }
}