using Application.Features.FindeksCredits.Command.CreateFindeksCredit;
using Application.Features.FindeksCredits.Command.DeleteFindeksCredit;
using Application.Features.FindeksCredits.Command.UpdateFindeksCredit;
using Application.Features.FindeksCredits.Dtos;
using Application.Features.FindeksCredits.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.FindeksCredits.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<FindeksCredit, CreateFindeksCreditCommand>().ReverseMap();
            CreateMap<FindeksCredit, UpdateFindeksCreditCommand>().ReverseMap();
            CreateMap<FindeksCredit, DeleteFindeksCreditCommand>().ReverseMap();

            CreateMap<FindeksCredit, FindeksCreditListDto>().ReverseMap();
            CreateMap<IPaginate<FindeksCredit>, FindeksCreditListModel>().ReverseMap();
        }
    }
}
