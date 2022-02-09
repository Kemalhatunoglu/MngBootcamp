﻿using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
