using PokeMom.Modelos.DTO;
using PokeMom.Utils;
using RestSharp;

namespace PokeMom.Menus;

internal class MenuListagemPokemon : Menu
{
    private string url;

    public MenuListagemPokemon(string titulo) : base(titulo)
    {
        url = "https://pokeapi.co/api/v2/pokemon/";
    }

    public override void Prompt()
    {
        base.Prompt();

        var client = new RestClient(url);
        var request = new RestRequest("/", Method.Get);
        var response = client.GetAsync<ListaPokemonDTO>(request).Result;

        foreach (var pokemon in response!.Pokemons!)
        {
            Console.WriteLine(pokemon.ToString());
        }

        Console.WriteLine("\nAperte \"1\" para voltar para a página anterior\n" +
            "Aperte \"2\" para ir para a próxima página" +
            "Aperte qualquer outra tecla para sair...");

        var tecla = Console.ReadKey();

        if (!PokeMomUtil.OpcaoValida(tecla.KeyChar.ToString())) return;

        switch (tecla.KeyChar)
        {
            case '1':
                if (response.PaginaAnterior != null)
                {
                    url = response.PaginaAnterior;
                }
                Prompt();
                break;
            case '2':
                if (response.ProximaPagina != null)
                {
                    url = response.ProximaPagina!;
                }
                Prompt();
                break;
        }
    }
}
