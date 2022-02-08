using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.DamageRecords.Commands.DeleteDamageRecord
{
    public class DeleteDamageRecordCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteDamageRecordCommandHandler : IRequestHandler<DeleteDamageRecordCommand, IResult>
        {
            private readonly IDamageRecordRepository _damageRecordRepository;

            public DeleteDamageRecordCommandHandler(IDamageRecordRepository damageRecordRepository)
            {
                _damageRecordRepository = damageRecordRepository;
            }

            public async Task<IResult> Handle(DeleteDamageRecordCommand request, CancellationToken cancellationToken)
            {
                var damageRecordToBeDeleted = await _damageRecordRepository.GetAsync(x => x.Id == request.Id);
                if (damageRecordToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);

                await _damageRecordRepository.DeleteAsync(damageRecordToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
