using Application.Constants;
using Application.Features.DamageRecords.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.DamageRecords.Queries.GetDamageRecordList
{
    public class GetDamageRecordListQuery : IRequest<IDataResult<DamageRecordListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetDamageRecordListQueryHandler : IRequestHandler<GetDamageRecordListQuery, IDataResult<DamageRecordListModel>>
        {
            private readonly IDamageRecordRepository _damageRecordRepository;
            private readonly IMapper _mapper;

            public GetDamageRecordListQueryHandler(IDamageRecordRepository damageRecordRepository, IMapper mapper)
            {
                _damageRecordRepository = damageRecordRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<DamageRecordListModel>> Handle(GetDamageRecordListQuery request, CancellationToken cancellationToken)
            {
                var damageRecord = await _damageRecordRepository.GetListAsync(
                   index: request.PageRequest.Page,
                   size: request.PageRequest.PageSize
                   );
                var mappedDamageRecord = _mapper.Map<DamageRecordListModel>(damageRecord);

                return new SuccessDataResult<DamageRecordListModel>(mappedDamageRecord, Message.SuccessGet);
            }
        }
    }
}
