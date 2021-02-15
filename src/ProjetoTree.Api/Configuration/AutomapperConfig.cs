using AutoMapper;
using ProjetoTree.Api.DTOs;
using ProjetoTree.Business.Models;

namespace ProjetoTree.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<StarshipVo, StarshipDTO>().ReverseMap();
            CreateMap<People, PeopleDTO>().ReverseMap();
            CreateMap<Planet, PlanetDTO>().ReverseMap();
            CreateMap<StarshipVo, StarshipVo>().ReverseMap();
        }
    }
}
