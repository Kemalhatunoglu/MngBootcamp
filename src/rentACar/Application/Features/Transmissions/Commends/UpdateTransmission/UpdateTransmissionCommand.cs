using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Transmissions.Commends.UpdateTransmission
{
    public class UpdateTransmissionCommand : IRequest<TransmissionUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, TransmissionUpdateDto>
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

            public async Task<TransmissionUpdateDto> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
            {
                var existTransmission = await _transmissionRepository.GetAsync(x => x.Id == request.Id);
                if (existTransmission == null) throw new Exception("Brand referance exception");

                await _transmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);
                var updateModelTransmission = _mapper.Map<Transmission>(request);
                await _transmissionRepository.UpdateAsync(updateModelTransmission);
                var mappedReturnTransmissionDto = _mapper.Map<TransmissionUpdateDto>(updateModelTransmission);
                return mappedReturnTransmissionDto;
            }
        }
    }
}
