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
        var requestLista = new RestRequest("/", Method.Get);
        var listaPokemon = client.GetAsync<ListaPokemonDTO>(requestLista).Result;

        foreach (var pokemon in listaPokemon!.Pokemons!)
        {
            var requestPokemon = new RestRequest($"/{pokemon.Nome}", Method.Get);
            var pokemonDTO = client.GetAsync<PokemonDTO>(requestPokemon).Result;

            Console.WriteLine(pokemonDTO);
        }

        Console.WriteLine("\nAperte \"1\" para voltar para a página anterior\n" +
            "Aperte \"2\" para ir para a próxima página\n" +
            "Aperte qualquer outra tecla para sair...");

        var tecla = Console.ReadKey();

        if (!PokeMomUtil.OpcaoValida(tecla.KeyChar.ToString())) return;

        switch (tecla.KeyChar)
        {
            case '1':
                if (listaPokemon.PaginaAnterior != null)
                {
                    url = listaPokemon.PaginaAnterior;
                }
                Prompt();
                break;
            case '2':
                if (listaPokemon.ProximaPagina != null)
                {
                    url = listaPokemon.ProximaPagina!;
                }
                Prompt();
                break;
        }
    }
}
