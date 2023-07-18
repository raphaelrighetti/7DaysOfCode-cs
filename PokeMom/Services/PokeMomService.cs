using PokeMom.Modelos.DTO;
using PokeMom.Models.DTO;
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

    public PokemonDTO DetalharPokemonEspecifico(string url)
    {
        var requestPokemon = new RestRequest(url, Method.Get);
        var pokemon = client.GetAsync<PokemonDTO>(requestPokemon).Result;

        return pokemon!;
    }
}
