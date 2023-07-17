using PokeMom.Modelos;

namespace PokeMom.Menus;

internal class MenuPokemonAdotado : Menu
{
    public MenuPokemonAdotado(string titulo, Usuario usuario) : base(titulo, usuario)
    {
    }

    public override void Prompt()
    {
        base.Prompt();

        if (Usuario!.Pokemon != null)
        {
            Console.WriteLine(Usuario.Pokemon);
        }
        else
        {
            Console.WriteLine("Você ainda não adotou um Pokémon :(");
        }

        Console.WriteLine("\nAperte qualquer tecla para sair...");

        Console.ReadKey();
    }
}
