using AutoMapper;
using Microsoft.Extensions.Options;
using Movie_Characters_API.DTOs.DTOsCharacter;
using Movie_Characters_API.DTOs.DTOsFranchise;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.DTOs.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<DTOCreateCharacter, Character>();
            CreateMap< DTOPutCharacter,Character>();
            CreateMap<Character, DTOGetCharacter>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(movieDomain => movieDomain.MoviesList.Select(Movies => $"api/v1/movies/{Movies.Id}").ToList()));
        }

        
                
    }
}
