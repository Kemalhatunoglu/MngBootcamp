using Application.Constants;
using Application.Features.Invoices.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Invoices.Queries.GetInvoiceByDateQuery
{
    public class GetInvoiceListByDateQuery : IRequest<IDataResult<InvoiceListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public DateTime? RentStartDate { get; set; } = new DateTime(1990, 01, 01);
        public DateTime? RentEndDate { get; set; } = DateTime.Now;
        public int InvoiceNo { get; set; }
        public class GetInvoiceListByDateHandler : IRequestHandler<GetInvoiceListByDateQuery, IDataResult<InvoiceListModel>>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMapper _mapper;

            public GetInvoiceListByDateHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<InvoiceListModel>> Handle(GetInvoiceListByDateQuery request, CancellationToken cancellationToken)
            {
                var invoices = await _invoiceRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize, predicate: p => p.CreationDate >= request.RentStartDate && p.CreationDate <= request.RentEndDate);
                var mappedInvoice = _mapper.Map<InvoiceListModel>(invoices);
                return new SuccessDataResult<InvoiceListModel>(mappedInvoice, Message.SuccessCreate);
            }
        }
    }
}
