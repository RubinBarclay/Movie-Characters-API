using AutoMapper;
using Microsoft.Extensions.Options;
using Movie_Characters_API.DTOs.DTOsFranchise;
using Movie_Characters_API.DTOs.DTOsMovie;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.DTOs.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<DTOCreateMovie, Movie>();
            CreateMap<DTOPutMovie, Movie>();
            CreateMap<Movie, DTOGetMovie>()
               .ForMember(dto => dto.Characters, options =>
               options.MapFrom(movieDomain => movieDomain.Characters.Select(Character => $"api/v1/characters/{Character.Id}").ToList()));

        }
       
    }
}
