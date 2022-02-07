using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities.Concete;

namespace Persistance.Repositories
{
    public class FindeksCreditRepository : EfRepositoryBase<FindeksCredit, BaseDbContext>, IFindeksCreditRepository
    {
        public FindeksCreditRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
