using Application.Features.IndividualCustomer.Commends.CreateIndividualCustomer;
using Application.Features.IndividualCustomer.Commends.DeleteIndividualCustomer;
using Application.Features.IndividualCustomer.Commends.UpdateIndividualCustomer;
using Application.Features.IndividualCustomer.Dtos;
using Application.Features.IndividualCustomer.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.IndividualCustomer.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Concete.IndividualCustomer, CreateIndividualCustomerCommand>().ReverseMap();
            CreateMap<Domain.Entities.Concete.IndividualCustomer, DeleteIndividualCustomerCommand>().ReverseMap();
            CreateMap<Domain.Entities.Concete.IndividualCustomer, UpdateIndividualCustomerCommand>().ReverseMap();

            CreateMap<Domain.Entities.Concete.IndividualCustomer, IndividualCustomerListDto>().ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Concete.IndividualCustomer>, IndividualCustomerListModel>().ReverseMap();
        }
    }
}
