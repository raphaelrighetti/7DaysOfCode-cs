using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokeMom.Modelos.DTO;

internal record HabilidadeDTO
{
    private string? habilidade;

    public JsonElement? Ability { get; init; }
    public string Habilidade
    {
        get
        {
            habilidade ??= JsonSerializer.Deserialize<ConteudoHabilidadeDTO>(Ability!.Value)!.Nome!;

            return habilidade;
        } 
    }

    private record ConteudoHabilidadeDTO
    {
        [JsonPropertyName("name")]
        public string? Nome { get; init; }
    }
}
