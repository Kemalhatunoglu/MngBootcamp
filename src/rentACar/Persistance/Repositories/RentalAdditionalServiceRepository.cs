using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities.Concete;

namespace Persistance.Repositories
{
    public class RentalAdditionalServiceRepository : EfRepositoryBase<RentalAdditionalService, BaseDbContext>, IRentalAdditionalServiceRepository
    {
        public RentalAdditionalServiceRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
