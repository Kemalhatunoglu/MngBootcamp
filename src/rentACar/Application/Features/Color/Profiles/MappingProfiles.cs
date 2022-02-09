using Application.Features.Color.Commends.CreateColor;
using Application.Features.Color.Commends.DeleteColor;
using Application.Features.Color.Commends.UpdateColor;
using Application.Features.Color.Dtos;
using Application.Features.Color.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Color.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Concete.Color, CreateColorCommand>().ReverseMap();
            CreateMap<Domain.Entities.Concete.Color, UpdateColorCommand>().ReverseMap();
            CreateMap<Domain.Entities.Concete.Color, DeleteColorCommand>().ReverseMap();

            CreateMap<Domain.Entities.Concete.Color, ColorUpdateDto>().ReverseMap();
            CreateMap<Domain.Entities.Concete.Color, ColorListDto>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.Concete.Color>, ColorListModel>().ReverseMap();
        }
    }
}
