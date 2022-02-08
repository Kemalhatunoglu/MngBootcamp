using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Invoices.Command.DeleteInvoice
{
    public class DeleteInvoiceCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, IResult>
        {
            private readonly IInvoiceRepository _invoiceRepository;

            public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
            {
                _invoiceRepository = invoiceRepository;
            }

            public async Task<IResult> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
            {
                var invoiceToBeDeleted = await _invoiceRepository.GetAsync(r => r.Id == request.Id);
                if (invoiceToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);
                await _invoiceRepository.DeleteAsync(invoiceToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
