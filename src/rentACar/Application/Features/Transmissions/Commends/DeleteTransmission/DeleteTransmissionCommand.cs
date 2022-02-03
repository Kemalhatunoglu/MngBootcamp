using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Transmissions.Commends.DeleteTransmission
{
    public class DeleteTransmissionCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, IResult>
        {
            private readonly ITransmissionRepository _transmissionRepository;

            public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository)
            {
                _transmissionRepository = transmissionRepository;
            }

            public async Task<IResult> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
            {
                Transmission transmissionToBeDeleted = await _transmissionRepository.GetAsync(c => c.Id == request.Id);

                if (transmissionToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);
                await _transmissionRepository.DeleteAsync(transmissionToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
