using PokeMom.Modelos;

namespace PokeMom.Menus;

internal abstract class Menu
{
    public Menu(string titulo, Usuario? usuario)
    {
        Titulo = titulo;
        Usuario = usuario;
    }

    public string Titulo { get; set; }
    public Usuario? Usuario { get; set; }

    public virtual void Prompt()
    {
        Usuario?.AtualizarStatsPokemon();

        Console.Clear();

        ExibirTitulo();
    }

    private void ExibirTitulo()
    {
        string barraEstilizada = string.Empty.PadLeft(Titulo.Length, '*');

        Console.WriteLine(barraEstilizada);
        Console.WriteLine(Titulo);
        Console.WriteLine($"{barraEstilizada}\n");
    }
}
