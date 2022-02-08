using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using Domain.Enums;
using MediatR;

namespace Application.Features.Invoices.Command.UpdateInvoice
{
    public class UpdateInvoiceCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public float RentalDayCount { get; set; }
        public double TotalFee { get; set; }
        public int CustomerId { get; set; }
        public CustomerType CustomerType { get; set; }

        public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, IResult>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMapper _mapper;

            public UpdateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
            {
                _mapper = mapper;
                _invoiceRepository = invoiceRepository;
            }

            public async Task<IResult> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
            {
                var updateModelInvoice = _mapper.Map<Invoice>(request);
                await _invoiceRepository.UpdateAsync(updateModelInvoice);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}