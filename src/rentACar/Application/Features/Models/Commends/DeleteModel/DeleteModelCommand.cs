using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Models.Commends.DeleteModel
{
    public class DeleteModelCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, IResult>
        {
            private readonly IModelRepository _modelRepository;

            public DeleteModelCommandHandler(IModelRepository modelRepository)
            {
                _modelRepository = modelRepository;
            }

            public async Task<IResult> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var deleteModel = await _modelRepository.GetAsync(m => m.Name == request.Name);

                if (deleteModel != null)
                {
                    await _modelRepository.DeleteAsync(deleteModel);
                    return new SuccessResult("The deletion is complete.");
                }
                return new ErrorResult("Deletion failed.");
            }
        }
    }
}
