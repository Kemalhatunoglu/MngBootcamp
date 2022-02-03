using Application.Features.Transmissions.Commends.CreateTransmission;
using Application.Features.Transmissions.Commends.DeleteTransmission;
using Application.Features.Transmissions.Commends.UpdateTransmission;
using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.Transmissions.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, UpdateTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, DeleteTransmissionCommand>().ReverseMap();

            CreateMap<Transmission, TransmissionUpdateDto>().ReverseMap();
            CreateMap<Transmission, TransmissionListDto>().ReverseMap();

            CreateMap<IPaginate<Transmission>, TransmissionListModel>().ReverseMap();
        }
    }
}
