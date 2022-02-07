using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.IndividualCustomer.Commends.DeleteIndividualCustomer
{
    public class DeleteIndividualCustomerCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, IResult>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;

            public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository)
            {
                _individualCustomerRepository = individualCustomerRepository;
            }

            public async Task<IResult> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var individualCustomerToBeDeleted = await _individualCustomerRepository.GetAsync(r => r.Id == request.Id);
                if (individualCustomerToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);
                await _individualCustomerRepository.DeleteAsync(individualCustomerToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
