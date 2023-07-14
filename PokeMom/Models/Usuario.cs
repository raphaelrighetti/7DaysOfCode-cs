namespace PokeMom.Modelos;

internal class Usuario
{
    public Usuario(string nome)
    {
        Nome = nome;
        PokemonAdotados = new();
    }

    public string Nome { get; set; }
    public List<Pokemon> PokemonAdotados { get; set; }
}
