using PokeMom.Menus;
using PokeMom.Modelos;

namespace PokeMom.Views;

internal class MenuBrincadeira : Menu
{
    public MenuBrincadeira(string titulo, Usuario? usuario) : base(titulo, usuario)
    {
    }

    public override void Prompt()
    {
        base.Prompt();

        if (Usuario!.Pokemon != null)
        {
            Usuario.Pokemon.Brincar();

            Console.WriteLine("Você brincou com o seu Pokémon!");
            Console.WriteLine("Confira abaixo os novos stats dele:\n");
            Console.WriteLine(Usuario.Pokemon);
        }
        else
        {
            Console.WriteLine("Você ainda não adotou nenhum Pokémon, vá adotar um!");
        }

        Console.WriteLine("\nAperte qualquer tecla para continuar...");

        Console.ReadKey();
    }
}
