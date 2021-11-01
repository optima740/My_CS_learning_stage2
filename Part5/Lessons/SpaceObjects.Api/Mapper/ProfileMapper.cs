using AutoMapper;
using SpaceObjects.Api.DTO;
using SpaceObjects.Api.Models;

namespace SpaceObjects.Api.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<AsteroidDto, Asteroid>();
            CreateMap<StarDto, Star>();
            CreateMap<PlanetDto, Planet>();
            CreateMap<BlackHoleDto, BlackHole>();
        }
    }
}
