using System.Text.Json.Serialization;

namespace PokeMom.Modelos.DTO;

internal class ListaPokemonDTO
{
    [JsonPropertyName("results")]
    public List<Pokemon>? Pokemons { get; set; }
    [JsonPropertyName("next")]
    public string? ProximaPagina { get; set; }
    [JsonPropertyName("previous")]
    public string? PaginaAnterior { get; set; }
}
