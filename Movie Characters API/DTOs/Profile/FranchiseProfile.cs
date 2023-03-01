using AutoMapper;
using Movie_Characters_API.DTOs.DTOsFranchise;
using Movie_Characters_API.Models;
using System.Drawing.Drawing2D;

namespace Movie_Characters_API.DTOs.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<DTOFranchise,Franchise>();
            CreateMap<Franchise, DTOGetFranchise>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(movieDomain => movieDomain.Movies.Select(Movies => $"api/v1/movies/{Movies.Id}").ToList()));
        }

    }
}
