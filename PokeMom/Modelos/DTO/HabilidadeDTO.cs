using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokeMom.Modelos.DTO;

internal record HabilidadeDTO
{
    public JsonElement? Ability { get; init; }
    public string Habilidade => JsonSerializer.Deserialize<ConteudoHabilidadeDTO>(Ability!.Value)!.Nome!;

    private record ConteudoHabilidadeDTO
    {
        [JsonPropertyName("name")]
        public string? Nome { get; init; }
    }
}
