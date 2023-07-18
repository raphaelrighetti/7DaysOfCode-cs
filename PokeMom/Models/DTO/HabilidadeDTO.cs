using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokeMom.Models.DTO;

internal record HabilidadeDTO
{
    private string? nome;

    public JsonElement? Ability { get; init; }
    public string Nome
    {
        get
        {
            nome ??= Ability!.Value.Deserialize<ConteudoHabilidadeDTO>()!.Nome!;

            return nome;
        }
    }

    private record ConteudoHabilidadeDTO
    {
        [JsonPropertyName("name")]
        public string? Nome { get; init; }
    }
}
