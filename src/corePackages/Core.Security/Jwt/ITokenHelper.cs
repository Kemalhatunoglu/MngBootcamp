using Core.Security.Entities;

namespace Core.Security.Jwt
{
    public interface ITokenHelper
    {
        Task<AccessToken> CreateTokenAsync(User user, List<OperationClaim> operationClaims);
    }
}
