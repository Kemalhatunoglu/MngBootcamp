using Application.Constants;
using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<IDataResult<UserListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IDataResult<UserListModel>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetUserListQueryHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<IDataResult<UserListModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedUser = _mapper.Map<UserListModel>(users);

                return new SuccessDataResult<UserListModel>(mappedUser, Message.SuccessGet);
            }
        }
    }
}
