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

        if (Usuario!.PokemonAdotados.Count != 0)
        {
            foreach (var pokemon in Usuario!.PokemonAdotados)
            {
                Console.WriteLine(pokemon);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Você ainda não adotou nenhum Pokémon :(");
        }

        Console.WriteLine("\nAperte qualquer tecla para sair...");

        Console.ReadKey();
    }
}
