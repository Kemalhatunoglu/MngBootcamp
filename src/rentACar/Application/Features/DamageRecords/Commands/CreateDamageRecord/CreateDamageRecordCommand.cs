using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.DamageRecords.Commands.CreateDamageRecord
{
    public class CreateDamageRecordCommand : IRequest<IDataResult<DamageRecord>>
    {
        public int CarId { get; set; }
        public string DamageExp { get; set; }

        public class CreateDamageRecordCommandHandler : IRequestHandler<CreateDamageRecordCommand, IDataResult<DamageRecord>>
        {
            private readonly IDamageRecordRepository _damageRecordRepository;
            private readonly IMapper _mapper;

            public CreateDamageRecordCommandHandler(IMapper mapper, IDamageRecordRepository damageRecordRepository)
            {
                _mapper = mapper;
                _damageRecordRepository = damageRecordRepository;
            }

            public async Task<IDataResult<DamageRecord>> Handle(CreateDamageRecordCommand request, CancellationToken cancellationToken)
            {
                var mappedDamageRecord = _mapper.Map<DamageRecord>(request);
                var damageRecordToAdd = await _damageRecordRepository.AddAsync(mappedDamageRecord);
                return new SuccessDataResult<DamageRecord>(damageRecordToAdd, Message.SuccessCreate);
            }
        }
    }
}
