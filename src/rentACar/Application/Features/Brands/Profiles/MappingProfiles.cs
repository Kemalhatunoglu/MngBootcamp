using Application.Features.Brands.Commends.CreateBrand;
using AutoMapper;
using Domain.Entities.Concete;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        }
    }
}
