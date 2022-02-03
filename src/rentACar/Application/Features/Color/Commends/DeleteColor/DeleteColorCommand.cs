using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Color.Commends.DeleteColor
{
    public class DeleteColorCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, IResult>
        {
            private readonly IColorRepository _colorRepository;

            public DeleteColorCommandHandler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
            }

            public async Task<IResult> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                var colorToBeDeleted = await _colorRepository.GetAsync(c => c.Id == request.Id);

                if (colorToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);
                await _colorRepository.DeleteAsync(colorToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
