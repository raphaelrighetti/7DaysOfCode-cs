using PokeMom.Menus;
using PokeMom.Modelos;

namespace PokeMom.Views;

internal class MenuAlimentacao : Menu
{
    public MenuAlimentacao(string titulo, Usuario? usuario) : base(titulo, usuario)
    {
    }

    public override void Prompt()
    {
        base.Prompt();

        if (Usuario!.Pokemon != null)
        {
            Usuario.Pokemon.Alimentar();

            Console.WriteLine("Você alimentou o seu Pokémon!");
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
