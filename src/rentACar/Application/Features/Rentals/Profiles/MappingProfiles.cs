using Application.Features.Rentals.Commands.CreateRental;
using Application.Features.Rentals.Commands.DeleteRental;
using Application.Features.Rentals.Commands.UpdateRental;
using Application.Features.Rentals.Dtos;
using Application.Features.Rentals.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.Rentals.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Rental, CreateRentalCommand>().ReverseMap();
            CreateMap<Rental, UpdateRentalCommand>().ReverseMap();
            CreateMap<Rental, DeleteRentalCommand>().ReverseMap();

            CreateMap<Rental, RentalListDto>().ReverseMap();
            CreateMap<IPaginate<Rental>, RentalListModel>().ReverseMap();
        }
    }
}
