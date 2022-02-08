﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities.Concete;

namespace Persistance.Repositories
{
    public class CityRepository : EfRepositoryBase<City, BaseDbContext>, ICityRepository
    {
        public CityRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
