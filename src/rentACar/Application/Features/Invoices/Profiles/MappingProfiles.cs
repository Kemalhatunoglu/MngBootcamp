using Application.Features.Invoices.Command.CreateInvoice;
using Application.Features.Invoices.Command.DeleteInvoice;
using Application.Features.Invoices.Command.UpdateInvoice;
using Application.Features.Invoices.Dtos;
using Application.Features.Invoices.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Concete;

namespace Application.Features.Invoices.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Invoice, CreateInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, DeleteInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceCommand>().ReverseMap();

            CreateMap<Invoice, InvoiceListDto>().ReverseMap();
            CreateMap<IPaginate<Invoice>, InvoiceListModel>().ReverseMap();
        }
    }
}
