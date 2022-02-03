using Application.Features.Brands.Dtos;
using Application.Features.Cars.Commends.CreateCar;
using Application.Features.Cars.Commends.DeleteCar;
using Application.Features.Cars.Commends.UpdateCar;
using Application.Features.Cars.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.Cars.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, UpdateCarCommand>().ReverseMap();
            CreateMap<Car, DeleteCarCommand>().ReverseMap();

            CreateMap<Car, BrandListDto>().ReverseMap();
            CreateMap<IPaginate<Car>, CarListModel>().ReverseMap();

        }
    }
}
