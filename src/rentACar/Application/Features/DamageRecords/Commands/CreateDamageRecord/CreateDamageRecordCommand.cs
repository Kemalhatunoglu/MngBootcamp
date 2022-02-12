using Application.Constants;
using Application.Features.DamageRecords.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.DamageRecords.Commands.CreateDamageRecord
{
    public class CreateDamageRecordCommand : IRequest<IDataResult<DamageRecordCommandDto>>
    {
        public int CarId { get; set; }
        public string DamageExp { get; set; }

        public class CreateDamageRecordCommandHandler : IRequestHandler<CreateDamageRecordCommand, IDataResult<DamageRecordCommandDto>>
        {
            private readonly IDamageRecordRepository _damageRecordRepository;
            private readonly IMapper _mapper;

            public CreateDamageRecordCommandHandler(IMapper mapper, IDamageRecordRepository damageRecordRepository)
            {
                _mapper = mapper;
                _damageRecordRepository = damageRecordRepository;
            }

            public async Task<IDataResult<DamageRecordCommandDto>> Handle(CreateDamageRecordCommand request, CancellationToken cancellationToken)
            {
                var mappedDamageRecord = _mapper.Map<DamageRecord>(request);
                var damageRecordToAdd = await _damageRecordRepository.AddAsync(mappedDamageRecord);
                var mapToDto = _mapper.Map<DamageRecordCommandDto>(damageRecordToAdd);
                return new SuccessDataResult<DamageRecordCommandDto>(mapToDto, Message.SuccessCreate);
            }
        }
    }
}
