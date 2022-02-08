using Application.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.DamageRecords.Commands.UpdateDamageRecord
{
    public class UpdateDamageRecordCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string DamageExp { get; set; }


        public class UpdateDamageRecordCommandHandler : IRequestHandler<UpdateDamageRecordCommand, IResult>
        {
            private readonly IDamageRecordRepository _damageRecordRepository;
            private readonly IMapper _mapper;

            public UpdateDamageRecordCommandHandler(IMapper mapper, IDamageRecordRepository damageRecordRepository)
            {
                _mapper = mapper;
                _damageRecordRepository = damageRecordRepository;
            }

            public async Task<IResult> Handle(UpdateDamageRecordCommand request, CancellationToken cancellationToken)
            {
                var updateModelDamageRecord = _mapper.Map<DamageRecord>(request);
                await _damageRecordRepository.UpdateAsync(updateModelDamageRecord);
                return new SuccessResult(Message.SuccessUpdate);
            }
        }
    }
}
