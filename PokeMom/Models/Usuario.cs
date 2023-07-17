namespace PokeMom.Modelos;

internal class Usuario
{
    public Usuario(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public Pokemon? Pokemon { get; set; }

    public void AtualizarStatsPokemon()
    {
        if (Pokemon == null) return;

        Pokemon.AtualizarStats();
    }
}
