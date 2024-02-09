using Microsoft.AspNetCore.Components;
using Pokedex_Frontend.Models;

namespace Pokedex_Frontend.Components;
public partial class PokemonComponent
{
    [Parameter]
    public Pokemon Pokemon { get; set; }
}

