﻿using Application.Features.Brands.Commends.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
        }
    }
}
