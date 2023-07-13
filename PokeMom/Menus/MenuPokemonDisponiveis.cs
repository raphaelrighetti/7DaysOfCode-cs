using PokeMom.Modelos;
using PokeMom.Modelos.DTO;
using PokeMom.Utils;
using RestSharp;

namespace PokeMom.Menus;

internal class MenuPokemonDisponiveis : Menu
{
    private RestClient client;

    public MenuPokemonDisponiveis(string titulo, Usuario usuario) : base(titulo, usuario)
    {
        client = new RestClient("https://pokeapi.co/api/v2/pokemon");
    }

    public override void Prompt()
    {
        base.Prompt();

        var requestLista = new RestRequest("/", Method.Get);
        var respostaLista = client.GetAsync<ListaPokemonDTO>(requestLista).Result;
        var listaPokemon = respostaLista!.Pokemons;

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
                if (respostaLista.PaginaAnterior != null)
                {
                    client = new RestClient(respostaLista.PaginaAnterior);
                }
                Prompt();
                return;
            case "p":
                if (respostaLista.ProximaPagina != null)
                {
                    client = new RestClient(respostaLista.ProximaPagina!);
                }
                Prompt();
                return;
        }

        if (PokeMomUtil.OpcaoEhNumeroPositivo(opcao!) && (int.Parse(opcao!) - 1) < listaPokemon.Count)
        {
            var pokemon = listaPokemon[int.Parse(opcao!) - 1];

            new MenuAdocaoPokemon("Menu Adocao Pokémon", Usuario, pokemon).Prompt();
        }
        else
        {
            Console.WriteLine("Digite uma opção válida.\n\n");
            Console.WriteLine("Aperte qualquer tecla para continuar...");

            Console.ReadKey();
        }

        Prompt();
        return;
    }
}
