using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.Entities.Concete;
using MediatR;

namespace Application.Features.FindeksCredits.Queries.GetFindeksCreditByCustomerId
{
    public class GetFindeksCreditByCustomerIdQuery : IRequest<IDataResult<FindeksCredit>>
    {
        public int CustomerId { get; set; }

        public class GetFindeksCreditByCustomerIdQueryHandler : IRequestHandler<GetFindeksCreditByCustomerIdQuery, IDataResult<FindeksCredit>>
        {
            private readonly IFindeksCreditRepository _findeksCreditRepository;

            public GetFindeksCreditByCustomerIdQueryHandler(IFindeksCreditRepository findeksCreditRepository)
            {
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IDataResult<FindeksCredit>> Handle(GetFindeksCreditByCustomerIdQuery request, CancellationToken cancellationToken)
            {
                FindeksCredit findeksCredit = await _findeksCreditRepository.GetAsync(x => x.CustomerId == request.CustomerId);
                if (findeksCredit.Id < 0) return new ErrorDataResult<FindeksCredit>(Message.ErrorGet);
                return new SuccessDataResult<FindeksCredit>(findeksCredit, Message.SuccessGet);
            }
        }
    }
}
