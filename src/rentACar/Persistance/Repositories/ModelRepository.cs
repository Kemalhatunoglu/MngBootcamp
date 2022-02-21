using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities.Concete;

namespace Persistance.Repositories
{
    public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
    {
        public ModelRepository(BaseDbContext context) : base(context)
        {

        }

        public List<ModelDetailDto> GetAllModelDetail()
        {
            IQueryable<ModelDetailDto> query = from model in Context.Models
                                               join brand in Context.Brands on model.BrandId equals brand.Id
                                               join fuel in Context.Fuels on model.FuelId equals fuel.Id
                                               join transmission in Context.Transmissions on model.TransmissionId equals transmission.Id
                                               select new ModelDetailDto
                                               {
                                                   Id = model.Id,
                                                   ModelName = model.Name,
                                                   BrandName = brand.Name,
                                                   FuelType = fuel.Name,
                                                   TransmissionType = transmission.Name,
                                                   DailyPrice = model.DailyPrice,
                                                   ImageUrl = model.ImageUrl
                                               };
            return query.ToList();
        }
    }
}
