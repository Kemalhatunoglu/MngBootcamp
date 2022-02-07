using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.CorporateCustomer.Commends.DeleteCorporateCustomer
{
    public class DeleteCorporateCustomerCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, IResult>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;

            public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
            }

            public async Task<IResult> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var corporateCustomerToBeDeleted = await _corporateCustomerRepository.GetAsync(r => r.Id == request.Id);
                if (corporateCustomerToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);
                await _corporateCustomerRepository.DeleteAsync(corporateCustomerToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
