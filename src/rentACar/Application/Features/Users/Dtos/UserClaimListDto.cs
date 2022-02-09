using Core.Security.Entities;

namespace Application.Features.Users.Dtos
{
    public class UserClaimListDto : UserOperationClaim
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
