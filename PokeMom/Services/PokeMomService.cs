using PokeMom.Modelos;
using PokeMom.Modelos.DTO;
using RestSharp;

namespace PokeMom.Controllers;

internal class PokeMomService
{
    private readonly RestClient client;

    public PokeMomService()
    {
        client = new RestClient();
    }

    public ListaPokemonDTO ListarPokemonDisponiveis(string url)
    {
        var requestLista = new RestRequest(url, Method.Get);
        var respostaLista = client.GetAsync<ListaPokemonDTO>(requestLista).Result;

        return respostaLista!;
    }

    public Pokemon DetalharPokemonEspecifico(string url)
    {
        var requestPokemon = new RestRequest(url, Method.Get);
        var pokemon = client.GetAsync<Pokemon>(requestPokemon).Result;

        return pokemon!;
    }
}
