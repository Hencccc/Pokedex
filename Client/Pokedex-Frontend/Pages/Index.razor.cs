using Blazored.Toast.Services;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Pokedex_Frontend.Store.PokemonStore;

namespace Pokedex_Frontend.Pages;

public partial class Index
{
    private string _input { get; set; } = string.Empty;

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    [Inject]
    private IState<PokemonState> PokemonState { get; set; }

    [Inject]
    private IToastService ToastService { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SubscribeToAction<PokemonFetchedByNameFailedAction>(ShowErrorToastWithName);
        SubscribeToAction<PokemonFetchedByIdFailedAction>(ShowErrorToastWithId);
    }

    private void DispatchFetchPokemon()
    {
        Dispatcher.Dispatch(int.TryParse(_input, out int n)
            ? new PokemonFetchByIdAction(n)
            : new PokemonFetchByNameAction(_input));

        _input = string.Empty;
    }

    private void ShowErrorToastWithName(PokemonFetchedByNameFailedAction action)
    {
        ToastService.ShowError($"Pokemon with the name: {action.Name} could not be found. Please try again.");
    }

    private void ShowErrorToastWithId(PokemonFetchedByIdFailedAction action)
    {
        ToastService.ShowError($"Pokemon with Id: {action.Id} could not be found. Please try again.");
    }
}