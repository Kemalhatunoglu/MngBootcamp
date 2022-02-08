using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.FindeksCredits.Queries.GetFindeksCreditById
{
    public class GetFindeksCreditByIdQuery : IRequest<IDataResult<FindeksCredit>>
    {
        public int Id { get; set; }

        public class GetFindeksCreditByIdQueryHandler : IRequestHandler<GetFindeksCreditByIdQuery, IDataResult<FindeksCredit>>
        {
            private readonly IFindeksCreditRepository _findeksCreditRepository;

            public GetFindeksCreditByIdQueryHandler(IFindeksCreditRepository findeksCreditRepository)
            {
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IDataResult<FindeksCredit>> Handle(GetFindeksCreditByIdQuery request, CancellationToken cancellationToken)
            {
                FindeksCredit findeksCredit = await _findeksCreditRepository.GetAsync(x => x.Id == request.Id);
                if (findeksCredit.Id < 0) return new ErrorDataResult<FindeksCredit>(Message.ErrorGet);
                return new SuccessDataResult<FindeksCredit>(findeksCredit, Message.SuccessGet);
            }
        }
    }
}
