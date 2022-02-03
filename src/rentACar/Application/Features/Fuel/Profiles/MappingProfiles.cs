using Application.Features.Fuel.Commends.CreateFuel;
using Application.Features.Fuel.Commends.DeleteFuel;
using Application.Features.Fuel.Commends.UpdateFuel;
using Application.Features.Fuel.Dtos;
using Application.Features.Fuel.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Fuel.Profiles
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Concete.Fuel, CreateFuelCommand>().ReverseMap();
            CreateMap<Domain.Entities.Concete.Fuel, UpdateFuelCommand>().ReverseMap();
            CreateMap<Domain.Entities.Concete.Fuel, DeleteFuelCommand>().ReverseMap();


            CreateMap<Domain.Entities.Concete.Fuel, FuelUpdateDto>().ReverseMap();
            CreateMap<Domain.Entities.Concete.Fuel, FuelListDto>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.Concete.Fuel>, FuelListModel>().ReverseMap();
        }
    }
}
