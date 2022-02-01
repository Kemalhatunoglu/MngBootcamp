using Application.Features.Cars.Commends.CreateCar;
using AutoMapper;
using Domain.Entities.Concete;

namespace Application.Features.Cars.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CreateCarCommand>().ReverseMap();
        }
    }
}
