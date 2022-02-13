using Application.Constants;
using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.AdditionalServices.Commands.DeleteAdditionalServices
{
    public class DeleteAdditionalServiceCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteAdditionalServiceCommandHandler : IRequestHandler<DeleteAdditionalServiceCommand, IResult>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly AdditionalServiceBusinessRules _additionalServiceBusinessRules;

            public DeleteAdditionalServiceCommandHandler(AdditionalServiceBusinessRules additionalServiceBusinessRules, IAdditionalServiceRepository additionalServiceRepository)
            {
                _additionalServiceBusinessRules = additionalServiceBusinessRules;
                _additionalServiceRepository = additionalServiceRepository;
            }

            public async Task<IResult> Handle(DeleteAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                await _additionalServiceBusinessRules.AdditionalServiceIsExists(request.Id);
                var deleteToAdditionalService = await _additionalServiceRepository.GetAsync(x => x.Id == request.Id);
                await _additionalServiceRepository.DeleteAsync(deleteToAdditionalService);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
