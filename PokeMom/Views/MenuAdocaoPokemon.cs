using PokeMom.Controllers;
using PokeMom.Modelos;
using PokeMom.Modelos.DTO;
using PokeMom.Utils;

namespace PokeMom.Menus;

internal class MenuAdocaoPokemon : Menu
{
    private readonly PokeMomService service;
    private readonly string url;

    public MenuAdocaoPokemon(string titulo, Usuario usuario, PokemonListagemDTO pokemon) : base(titulo, usuario)
    {
        url = $"https://pokeapi.co/api/v2/pokemon/{pokemon.Nome}";
        service = new PokeMomService();
    }

    public override void Prompt()
    {
        base.Prompt();

        var pokemon = service.DetalharPokemonEspecifico(url);

        Console.WriteLine(pokemon);
        Console.WriteLine("\nDigite \"1\" e aperte enter para adotar este Pokémon\n" +
            "Digite qualquer coisa ou apenas aperte enter para voltar para a listagem de Pokémon...");

        var opcao = Console.ReadLine();

        if (!PokeMomUtil.OpcaoEhValida(opcao) ||
            !PokeMomUtil.OpcaoEhNumeroPositivo(opcao!) ||
            int.Parse(opcao!) > 1 || int.Parse(opcao!) < 0)
        {
            return;
        }
        else
        {
            Console.Clear();

            Usuario!.PokemonAdotados.Add(pokemon!);

            Console.WriteLine($"{pokemon!.Nome} adotado com sucesso!");
            Console.WriteLine("\nAperte qualquer tecla para continuar...");

            Console.ReadKey();
        }
    }
}
