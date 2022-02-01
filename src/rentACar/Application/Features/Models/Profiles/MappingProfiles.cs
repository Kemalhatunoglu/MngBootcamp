using Application.Features.Models.Commends.CreateModel;
using AutoMapper;
using Domain.Entities.Concete;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, CreateModelCommand>().ReverseMap();
        }
    }
}
