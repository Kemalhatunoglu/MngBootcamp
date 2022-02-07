using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities.Concete;

namespace Persistance.Repositories
{
    public class CorporateCustomerRepository : EfRepositoryBase<CorporateCustomer, BaseDbContext>, ICorporateCustomerRepository
    {
        public CorporateCustomerRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
