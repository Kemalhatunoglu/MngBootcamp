using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Queries.GetUserClaims
{
    public class GetUserClaimQuery:IRequest<UserClaimListDto>
    {
        
    }
}
