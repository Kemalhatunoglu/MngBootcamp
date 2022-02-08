using Application.Features.DamageRecords.Commands.CreateDamageRecord;
using Application.Features.DamageRecords.Commands.DeleteDamageRecord;
using Application.Features.DamageRecords.Commands.UpdateDamageRecord;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.DamageRecords.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DamageRecord, CreateDamageRecordCommand>().ReverseMap();
            CreateMap<DamageRecord, UpdateDamageRecordCommand>().ReverseMap();
            CreateMap<DamageRecord, DeleteDamageRecordCommand>().ReverseMap();

            //CreateMap<DamageRecord, DamageRecordListDto>().ReverseMap();

            //CreateMap<IPaginate<DamageRecord>, DamageRecordListModel>().ReverseMap();
        }
    }
}
