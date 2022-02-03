using Application.Services.Repositories;
using Core.Persistence.Repositories;

namespace Persistance.Repositories
{
    public class FuelRepository : EfRepositoryBase<Domain.Entities.Concete.Fuel, BaseDbContext>, IFuelRepository
    {
        public FuelRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
