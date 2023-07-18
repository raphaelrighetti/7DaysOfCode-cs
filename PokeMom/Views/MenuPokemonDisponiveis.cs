using PokeMom.Controllers;
using PokeMom.Modelos;
using PokeMom.Utils;

namespace PokeMom.Menus;

internal class MenuPokemonDisponiveis : Menu
{
    private string url;
    private readonly PokeMomService service;

    public MenuPokemonDisponiveis(string titulo, Usuario usuario) : base(titulo, usuario)
    {
        url = "https://pokeapi.co/api/v2/pokemon";
        service = new PokeMomService();
    }

    public override void Prompt()
    {
        base.Prompt();

        var listaPokemonDTO = service.ListarPokemonDisponiveis(url);

        if (listaPokemonDTO == null)
        {
            MensagemErroInesperado();
            return;
        }

        var listaPokemon = listaPokemonDTO.Pokemons;

        for (int i = 0; i < listaPokemon!.Count; i++)
        {
            var pokemon = listaPokemon[i];

            Console.WriteLine($"{i + 1} - {PokeMomUtil.Capitalize(pokemon.Nome!)}");
        }

        Console.WriteLine("\nDigite o número do Pokémon desejado e aperte enter para ver mais detalhes sobre ele\n" +
            "Digite \"a\" e aperte enter para voltar para a página anterior\n" +
            "Digite \"p\" e aperte enter para ir para a próxima página\n" +
            "Não digite nada e aperte enter para sair...");

        var opcao = Console.ReadLine();

        if (!PokeMomUtil.OpcaoEhValida(opcao)) return;

        switch (opcao)
        {
            case "a":
                if (listaPokemonDTO.PaginaAnterior != null)
                {
                    url = listaPokemonDTO.PaginaAnterior;
                }
                Prompt();
                return;
            case "p":
                if (listaPokemonDTO.ProximaPagina != null)
                {
                    url = listaPokemonDTO.ProximaPagina!;
                }
                Prompt();
                return;
        }

        if (PokeMomUtil.OpcaoEhNumeroPositivo(opcao!) && (int.Parse(opcao!) - 1) < listaPokemon.Count)
        {
            var pokemon = listaPokemon[int.Parse(opcao!) - 1];

            new MenuAdocaoPokemon("Menu Adocao Pokémon", Usuario!, pokemon).Prompt();
        }
        else
        {
            Console.Clear();

            Console.WriteLine("Digite uma opção válida.\n\n");
            Console.WriteLine("Aperte qualquer tecla para continuar...");

            Console.ReadKey();
        }

        Prompt();
        return;
    }
}
