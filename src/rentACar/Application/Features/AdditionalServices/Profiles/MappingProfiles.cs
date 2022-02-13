using Application.Features.AdditionalServices.Commands.CreateAdditionalServices;
using Application.Features.AdditionalServices.Commands.UpdateAdditionalServices;
using Application.Features.AdditionalServices.Dtos;
using Application.Features.AdditionalServices.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.AdditionalServices.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AdditionalService, CreateAdditionalServiceCommand>().ReverseMap();
            CreateMap<AdditionalService, UpdateAdditionalServiceCommand>().ReverseMap();
            CreateMap<AdditionalService, AdditionalServiceCommandDto>().ReverseMap();

            CreateMap<AdditionalService, AdditionalServiceListDto>().ReverseMap();
            CreateMap<IPaginate<AdditionalService>, AdditionalServiceListModel>().ReverseMap();
        }
    }
}
