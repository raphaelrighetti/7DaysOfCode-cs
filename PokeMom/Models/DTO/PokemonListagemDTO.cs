using PokeMom.Utils;
using System.Text.Json.Serialization;

namespace PokeMom.Modelos.DTO;

internal record PokemonListagemDTO
{
    [JsonPropertyName("name")]
    public string? Nome { get; init; }
}
