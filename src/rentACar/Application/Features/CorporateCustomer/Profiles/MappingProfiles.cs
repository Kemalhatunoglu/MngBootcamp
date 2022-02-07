using Application.Features.CorporateCustomer.Commends.CreateCorporateCustomer;
using Application.Features.CorporateCustomer.Commends.DeleteCorporateCustomer;
using Application.Features.CorporateCustomer.Commends.UpdateCorporateCustomer;
using Application.Features.CorporateCustomer.Dtos;
using Application.Features.CorporateCustomer.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.CorporateCustomer.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Concete.CorporateCustomer, CreateCorporateCustomerCommand>().ReverseMap();
            CreateMap<Domain.Entities.Concete.CorporateCustomer, DeleteCorporateCustomerCommand>().ReverseMap();
            CreateMap<Domain.Entities.Concete.CorporateCustomer, UpdateCorporateCustomerCommand>().ReverseMap();

            CreateMap<Domain.Entities.Concete.CorporateCustomer, CorporateCustomerListDto>().ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Concete.CorporateCustomer>, CorporateCustomerListModel>().ReverseMap();
        }
    }
}
