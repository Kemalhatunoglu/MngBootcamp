using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class UserOperationClaim : Entity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

    }
}
