using Application.Constants;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<IDataResult<User>>
    {
        public int Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IDataResult<User>>
        {
            private readonly IUserRepository _userRepository;

            public GetUserByIdQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<IDataResult<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var userResponse = await _userRepository.GetAsync(brand => brand.Id == request.Id);
                if (userResponse.Id < 0) return new ErrorDataResult<User>(Message.ErrorGet);

                return new SuccessDataResult<User>(userResponse, Message.SuccessGet);
            }
        }
    }
}
