using PokeMom.Menus;
using PokeMom.Modelos;

namespace PokeMom.Views;

internal class MenuMorte : Menu
{
    public MenuMorte(string titulo, Usuario? usuario) : base(titulo, usuario)
    {
    }

    public override void Prompt()
    {
        base.Prompt();

        Console.WriteLine($"{Usuario!.Pokemon!.Nome} morreu...");
        Console.WriteLine($"Causa da morte: ");
        Console.WriteLine("É hora de dizer adeus.");
        Console.WriteLine("\nAperte qualquer tecla para finalizar...");

        Console.ReadKey();

        Environment.Exit(0);
    }
}
