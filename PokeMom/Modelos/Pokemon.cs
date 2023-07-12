using PokeMom.Utils;
using System.Text.Json.Serialization;

namespace PokeMom.Modelos;

internal class Pokemon
{
    private string? nome;

    [JsonPropertyName("name")]
    public string? Nome
    {
        get
        {
            return PokeMomUtil.Capitalize(nome!);
        }
        set
        {
            nome = value;
        }
    }
    [JsonPropertyName("url")]
    public string? URL { get; set; }

    public override string ToString()
    {
        return $"Nome: {Nome}, URL: {URL}";
    }
}
