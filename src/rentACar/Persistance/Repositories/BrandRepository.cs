using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities.Concete;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
    {
        public BrandRepository(BaseDbContext context) : base(context)
        {

        }

        public async Task<List<BrandDetailDto>> GetAllBrandDetail()
        {
            IQueryable<BrandDetailDto> query = from brand in Context.Brands
                                               select new BrandDetailDto
                                               {
                                                   Id = brand.Id,
                                                   BrandName = brand.Name,
                                               };
            var brands = await query.ToListAsync();
            foreach (var brand in brands)
            {
                brand.Models = await (from model in Context.Models
                                      join car in Context.Cars on model.Id equals car.ModelId
                                      join fuel in Context.Fuels on model.FuelId equals fuel.Id
                                      join transmission in Context.Transmissions on model.TransmissionId equals transmission.Id
                                      where model.BrandId == brand.Id
                                      select new ModelDetailDto
                                      {
                                          Id = model.Id,
                                          ModelName = model.Name,
                                          BrandName = brand.BrandName,
                                          FuelType = fuel.Name,
                                          TransmissionType = transmission.Name,
                                          DailyPrice = model.DailyPrice,
                                          ImageUrl = model.ImageUrl
                                      }).ToListAsync();
            }

            return brands;
        }
    }
}