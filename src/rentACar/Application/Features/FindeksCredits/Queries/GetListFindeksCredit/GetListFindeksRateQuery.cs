using Application.Constants;
using Application.Features.FindeksCredits.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.FindeksCredits.Queries.GetListFindeksCredit
{
    public class GetListFindeksRateQuery : IRequest<IDataResult<FindeksCreditListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListFindeksRateQueryHandler : IRequestHandler<GetListFindeksRateQuery, IDataResult<FindeksCreditListModel>>
        {
            private readonly IFindeksCreditRepository _findeksCreditRepository;
            private readonly IMapper _mapper;

            public GetListFindeksRateQueryHandler(IMapper mapper, IFindeksCreditRepository findeksCreditRepository)
            {
                _mapper = mapper;
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IDataResult<FindeksCreditListModel>> Handle(GetListFindeksRateQuery request, CancellationToken cancellationToken)
            {
                var findeksCredit = await _findeksCreditRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedBrand = _mapper.Map<FindeksCreditListModel>(findeksCredit);

                return new SuccessDataResult<FindeksCreditListModel>(mappedBrand, Message.SuccessGet);
            }
        }
    }
}
