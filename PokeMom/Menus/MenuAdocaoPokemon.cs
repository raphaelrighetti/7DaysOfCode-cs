using PokeMom.Modelos;
using PokeMom.Modelos.DTO;
using PokeMom.Utils;
using RestSharp;

namespace PokeMom.Menus;

internal class MenuAdocaoPokemon : Menu
{
    private readonly RestClient client;

    public MenuAdocaoPokemon(string titulo, Usuario usuario, PokemonListagemDTO pokemon) : base(titulo, usuario)
    {
        client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemon.Nome}");
    }

    public override void Prompt()
    {
        base.Prompt();

        var requestPokemon = new RestRequest($"/", Method.Get);
        var pokemon = client.GetAsync<Pokemon>(requestPokemon).Result;

        Console.WriteLine(pokemon);
        Console.WriteLine("\nAperte \"1\" para adotar este Pokémon\n" +
            "Aperte qualquer outra tecla para voltar para a listagem de Pokémon...");

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

            Usuario.PokemonAdotados.Add(pokemon!);

            Console.WriteLine($"{pokemon!.Nome} adotado com sucesso!");
            Console.WriteLine("\nAperte qualquer tecla para continuar...");

            Console.ReadKey();
        }
    }
}
