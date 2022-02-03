using Application.Constants;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.Transmissions.Commends.CreateTransmission
{
    public class CreateTransmissionCommand : IRequest<IDataResult<Transmission>>
    {
        public string Name { get; set; }

        public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, IDataResult<Transmission>>
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

            public async Task<IDataResult<Transmission>> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {
                await _transmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);
                Transmission mappedTransmission = _mapper.Map<Transmission>(request);
                Transmission transmissionToAdd = await _transmissionRepository.AddAsync(mappedTransmission);
                return new SuccessDataResult<Transmission>(transmissionToAdd, Message.SuccessCreate);
            }
        }
    }
}
