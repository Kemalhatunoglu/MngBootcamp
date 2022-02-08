using Application.Constants;
using Application.Features.Invoices.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Invoices.Queries.GetInvoiceListByCustomerId
{
    public class GetInvoiceListByCustomerQuery : IRequest<IDataResult<InvoiceListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public int CustomerId { get; set; }

        public class GetInvoicesBuCustomerHandler : IRequestHandler<GetInvoiceListByCustomerQuery, IDataResult<InvoiceListModel>>
        {
            IInvoiceRepository _invoiceRepository;
            IMapper _mapper;

            public GetInvoicesBuCustomerHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<InvoiceListModel>> Handle(GetInvoiceListByCustomerQuery request, CancellationToken cancellationToken)
            {
                var invoices = await _invoiceRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize, predicate: p => p.CustomerId == request.CustomerId);
                var mappedInvoices = _mapper.Map<InvoiceListModel>(invoices);
                return new SuccessDataResult<InvoiceListModel>(mappedInvoices, Message.SuccessCreate);
            }
        }
    }
}
