using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities.Concete;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class AdditionalServiceRepository : EfRepositoryBase<AdditionalService, BaseDbContext>, IAdditionalServiceRepository
    {
        public AdditionalServiceRepository(BaseDbContext context) : base(context)
        {

        }

        public Task<List<AdditionalServiceDto>> GetAll()
        {
            IQueryable<AdditionalServiceDto> query = from additionalService in Context.AdditionalServices
                                                     select new AdditionalServiceDto
                                                     {
                                                         Id = additionalService.Id,
                                                         Name = additionalService.Name,
                                                         Count = additionalService.Count,
                                                         DailyPrice = additionalService.DailyPrice
                                                     };

            return query.ToListAsync();
        }
    }
}
