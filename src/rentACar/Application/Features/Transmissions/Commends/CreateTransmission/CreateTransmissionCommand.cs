using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Transmissions.Commends.CreateTransmission
{
    public class CreateTransmissionCommand : IRequest<Transmission>
    {
        public string Name { get; set; }

        public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, Transmission>
        {
            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;
            private readonly TransmissionBusinessRules _transmissionBusinessRules;

            public CreateTransmissionCommandHandler(TransmissionBusinessRules transmissionBusinessRules, IMapper mapper, ITransmissionRepository transmissionRepository)
            {
                _transmissionBusinessRules = transmissionBusinessRules;
                _mapper = mapper;
                _transmissionRepository = transmissionRepository;
            }

            public async Task<Transmission> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {
                await _transmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedTransmission = _mapper.Map<Transmission>(request);
                var createdTransmission = await _transmissionRepository.AddAsync(mappedTransmission);
                return createdTransmission;
            }
        }
    }
}
