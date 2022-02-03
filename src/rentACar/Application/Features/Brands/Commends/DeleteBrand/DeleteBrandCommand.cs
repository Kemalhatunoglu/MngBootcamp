using Application.Constants;
using Application.Services.Repositories;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Brands.Commends.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, IResult>
        {
            private readonly IBrandRepository _brandRepository;

            public DeleteBrandCommandHandler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            public async Task<IResult> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                var brandToBeDeleted = await _brandRepository.GetAsync(b => b.Id == request.Id);

                if (brandToBeDeleted == null) return new ErrorResult(Message.ErrorDelete);

                await _brandRepository.DeleteAsync(brandToBeDeleted);
                return new SuccessResult(Message.SuccessDelete);
            }
        }
    }
}
