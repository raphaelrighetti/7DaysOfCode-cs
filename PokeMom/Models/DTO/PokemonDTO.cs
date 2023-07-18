using PokeMom.Utils;
using System.Text.Json.Serialization;

namespace PokeMom.Models.DTO;

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
    [JsonPropertyName("weight")]
    public int Peso { get; init; }
    [JsonPropertyName("abilities")]
    public List<HabilidadeDTO>? Habilidades { get; init; }

    public override string ToString()
    {
        return $"Nome: {Nome}\n" +
            $"Altura: {Altura}\n" +
            $"Peso: {Peso}\n" +
            $"Primeira habilidade: {Habilidades![0].Nome}";
    }
}
