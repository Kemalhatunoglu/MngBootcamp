using Application.Constants;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Transmissions.Commends.UpdateTransmission
{
    public class UpdateTransmissionCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, IResult>
        {
            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;
            private readonly TransmissionBusinessRules _transmissionBusinessRules;

            public UpdateTransmissionCommandHandler(TransmissionBusinessRules transmissionBusinessRules, IMapper mapper, ITransmissionRepository transmissionRepository)
            {
                _transmissionBusinessRules = transmissionBusinessRules;
                _mapper = mapper;
                _transmissionRepository = transmissionRepository;
            }

            public async Task<IResult> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
            {
                await _transmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);

                Transmission updateModelTransmission = _mapper.Map<Transmission>(request);
                await _transmissionRepository.UpdateAsync(updateModelTransmission);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
