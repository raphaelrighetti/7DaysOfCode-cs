namespace PokeMom.Menus;

internal abstract class Menu
{
    public Menu(string titulo)
    {
        Titulo = titulo;
    }

    public string Titulo { get; set; }

    public virtual void Prompt()
    {
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
