using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Models.Commends.DeleteModel
{
    public class DeleteModelCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, IResult>
        {
            private readonly IModelRepository _modelRepository;

            public DeleteModelCommandHandler(IModelRepository modelRepository)
            {
                _modelRepository = modelRepository;
            }

            public async Task<IResult> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var modelToBeDeleted = await _modelRepository.GetAsync(m => m.Id == request.Id);

                if (modelToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);

                await _modelRepository.DeleteAsync(modelToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
