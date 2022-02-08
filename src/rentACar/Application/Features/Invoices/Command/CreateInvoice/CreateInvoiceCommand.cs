using Application.Constants;
using Application.Features.Invoices.Rules.Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using Domain.Enums;
using MediatR;

namespace Application.Features.Invoices.Command.CreateInvoice
{
    public class CreateInvoiceCommand : IRequest<IDataResult<Invoice>>
    {
        public int InvoiceNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public float RentalDayCount { get; set; }
        public double TotalFee { get; set; }
        public int CustomerId { get; set; }
        public CustomerType CustomerType { get; set; }

        public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, IDataResult<Invoice>>
        {
            private readonly IMapper _mapper;
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly InvoiceBusinessRules _invoiceBusinessRules;

            public CreateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository, InvoiceBusinessRules invoiceBusinessRules)
            {
                _mapper = mapper;
                _invoiceRepository = invoiceRepository;
                _invoiceBusinessRules = invoiceBusinessRules;
            }

            public async Task<IDataResult<Invoice>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
            {
                var mappedInvoice = _mapper.Map<Invoice>(request);
                var createInvoice = await _invoiceRepository.AddAsync(mappedInvoice);
                return new SuccessDataResult<Invoice>(createInvoice, Message.SuccessCreate);
            }
        }
    }
}
