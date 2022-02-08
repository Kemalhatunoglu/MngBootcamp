using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.FindeksCredits.Command.DeleteFindeksCredit
{
    public class DeleteFindeksCreditCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteFindeksCreditCommandHandler : IRequestHandler<DeleteFindeksCreditCommand, IResult>
        {
            private readonly IFindeksCreditRepository _findeksCreditRepository;

            public DeleteFindeksCreditCommandHandler(IFindeksCreditRepository findeksCreditRepository)
            {
                _findeksCreditRepository = findeksCreditRepository;
            }

            public async Task<IResult> Handle(DeleteFindeksCreditCommand request, CancellationToken cancellationToken)
            {
                var findeksCreditToBeDeleted = await _findeksCreditRepository.GetAsync(f => f.Id == request.Id);
                if (findeksCreditToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);
                await _findeksCreditRepository.DeleteAsync(findeksCreditToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
