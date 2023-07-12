using PokeMom.Utils;
using System.Text.Json.Serialization;

namespace PokeMom.Modelos.DTO;

internal record PokemonDTO
{
    private string? nome;

    [JsonPropertyName("name")]
    public string? Nome
    {
        get
        {
            return PokeMomUtil.Capitalize(nome!);
        }
        init
        {
            nome = value;
        }
    }
    [JsonPropertyName("height")]
    public int Altura { get; init; }
    [JsonPropertyName("abilities")]
    public List<HabilidadeDTO>? Habilidades { get; init; }

    public override string ToString()
    {
        return $"Nome: {Nome}, Altura: {Altura}, Primeira habilidade: {Habilidades![0].Habilidade}";
    }
}
