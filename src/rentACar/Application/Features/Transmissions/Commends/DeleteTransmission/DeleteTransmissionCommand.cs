using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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
                var result = await _transmissionRepository.GetAsync(c => c.Id == request.Id);
                if (result == null) throw new BusinessException("There was an error in deletion.");
                await _transmissionRepository.DeleteAsync(result);
                return new SuccessResult("The deletion was successful.");
            }
        }
    }
}
