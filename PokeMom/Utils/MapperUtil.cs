using AutoMapper;
using PokeMom.Models;
using PokeMom.Models.DTO;

namespace PokeMom.Utils;

internal static class MapperUtil
{
    public static Pokemon ConverterPokemonDTOParaPokemon(PokemonDTO pokemonDTO)
    {
        var config = new MapperConfiguration(config => 
        { 
            config.CreateMap<PokemonDTO, Pokemon>();
            config.CreateMap<HabilidadeDTO, Habilidade>();
        });
        var mapper = config.CreateMapper();

        return mapper.Map<Pokemon>(pokemonDTO);
    }
}
