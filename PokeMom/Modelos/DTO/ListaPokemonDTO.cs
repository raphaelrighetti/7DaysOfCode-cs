using System.Text.Json.Serialization;

namespace PokeMom.Modelos.DTO;

internal record ListaPokemonDTO
{
    [JsonPropertyName("results")]
    public List<PokemonListagemDTO>? Pokemons { get; init; }
    [JsonPropertyName("next")]
    public string? ProximaPagina { get; init; }
    [JsonPropertyName("previous")]
    public string? PaginaAnterior { get; init; }
}
