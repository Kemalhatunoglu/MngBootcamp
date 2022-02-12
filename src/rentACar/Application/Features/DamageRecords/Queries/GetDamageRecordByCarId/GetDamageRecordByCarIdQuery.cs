using Application.Constants;
using Application.Features.DamageRecords.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.DamageRecords.Queries.GetDamageRecordByCarId
{
    public class GetDamageRecordByCarIdQuery : IRequest<IDataResult<DamageRecordListDto>>
    {
        public int CarId { get; set; }

        public class GetDamageRecordByCarIdQueryHandler : IRequestHandler<GetDamageRecordByCarIdQuery, IDataResult<DamageRecordListDto>>
        {
            private readonly IDamageRecordRepository _damageRecordRepository;
            private readonly IMapper _mapper;

            public GetDamageRecordByCarIdQueryHandler(IMapper mapper, IDamageRecordRepository damageRecordRepository)
            {
                _mapper = mapper;
                _damageRecordRepository = damageRecordRepository;
            }

            public async Task<IDataResult<DamageRecordListDto>> Handle(GetDamageRecordByCarIdQuery request, CancellationToken cancellationToken)
            {
                var damageRecord = await _damageRecordRepository.GetAsync(d => d.CarId == request.CarId);

                if (damageRecord == null) return new ErrorDataResult<DamageRecordListDto>(null, Message.DamageRecordNotFound);

                var mapDamageRecord = _mapper.Map<DamageRecordListDto>(damageRecord);
                return new SuccessDataResult<DamageRecordListDto>(mapDamageRecord, Message.SuccessGet);
            }
        }
    }
}
