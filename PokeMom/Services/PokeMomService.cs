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

    public ListaPokemonDTO? ListarPokemonDisponiveis(string url)
    {
        var requestLista = new RestRequest(url, Method.Get);
        ListaPokemonDTO? respostaLista;
        
        try
        {
            respostaLista = client.GetAsync<ListaPokemonDTO>(requestLista).Result;
        }
        catch (Exception ex)
        {
            MostrarMensagemExcecao(ex.Message);
            return null;
        }

        return respostaLista;
    }

    public PokemonDTO? DetalharPokemonEspecifico(string url)
    {
        var requestPokemon = new RestRequest(url, Method.Get);
        PokemonDTO? pokemonDTO;

        try
        {
            pokemonDTO = client.GetAsync<PokemonDTO>(requestPokemon).Result;
        }
        catch (Exception ex)
        {
            MostrarMensagemExcecao(ex.Message);
            return null;
        }

        return pokemonDTO;
    }

    private void MostrarMensagemExcecao(string mensagem)
    {
        Console.Clear();

        Console.WriteLine($"Deu pau: {mensagem}");
        Console.WriteLine("\nAperte qualquer tecla para continuar...");

        Console.ReadKey();
    }
}
