using PokeMom.Modelos;

namespace PokeMom.Menus;

internal class MenuPokemonAdotados : Menu
{
    public MenuPokemonAdotados(string titulo, Usuario usuario) : base(titulo, usuario)
    {
    }

    public override void Prompt()
    {
        base.Prompt();

        foreach (var pokemon in Usuario.PokemonAdotados)
        {
            Console.WriteLine(pokemon);
            Console.WriteLine();
        }

        Console.WriteLine("\nAperte qualquer tecla para sair...");

        Console.ReadKey();
    }
}
