using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities.Concete;

namespace Persistance.Repositories
{
    public class DamageRecordRepository : EfRepositoryBase<DamageRecord, BaseDbContext>, IDamageRecordRepository
    {
        public DamageRecordRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
