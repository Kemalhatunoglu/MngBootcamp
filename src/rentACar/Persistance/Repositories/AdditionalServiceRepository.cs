﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities.Concete;

namespace Persistance.Repositories
{
    public class AdditionalServiceRepository : EfRepositoryBase<AdditionalService, BaseDbContext>, IAdditionalServiceRepository
    {
        public AdditionalServiceRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
