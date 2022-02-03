using Application.Features.Models.Commends.CreateModel;
using Application.Features.Models.Commends.DeleteModel;
using Application.Features.Models.Commends.UpdateModel;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, UpdateModelCommand>().ReverseMap();
            CreateMap<Model, DeleteModelCommand>().ReverseMap();

            CreateMap<Model, ModelUpdateDto>().ReverseMap();
            CreateMap<Model, ModelListDto>().ReverseMap();

            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
        }
    }
}
