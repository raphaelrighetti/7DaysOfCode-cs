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

    protected void MensagemErroInesperado()
    {
        Console.Clear();

        Console.WriteLine("Ocorreu um erro inseperado ao tentar acessar recursos da API, tente novamente mais tarde!");
        Console.WriteLine("\nAperte qualquer tecla para continuar...");

        Console.ReadKey();
    }

    private void ExibirTitulo()
    {
        string barraEstilizada = string.Empty.PadLeft(Titulo.Length, '*');

        Console.WriteLine(barraEstilizada);
        Console.WriteLine(Titulo);
        Console.WriteLine($"{barraEstilizada}\n");
    }
}
