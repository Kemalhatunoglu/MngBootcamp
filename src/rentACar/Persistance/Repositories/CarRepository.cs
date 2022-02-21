using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities.Concete;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class CarRepository : EfRepositoryBase<Car, BaseDbContext>, ICarRepository
    {
        public CarRepository(BaseDbContext context) : base(context)
        {

        }

        public Task<List<CarDetailDto>> GetAllCarDetailToRental()
        {
            IQueryable<CarDetailDto> result =
                            from car in Context.Cars
                            join model in Context.Models on car.ModelId equals model.Id
                            join brand in Context.Brands on model.BrandId equals brand.Id
                            join color in Context.Colors on car.ColorId equals color.Id
                            join city in Context.Cities on car.CityId equals city.Id
                            select new CarDetailDto
                            {
                                CarId = car.Id,
                                BrandName = brand.Name,
                                ModelName = model.Name,
                                CityName = city.Name,
                                Color = color.Name,
                                Plate = car.Plate,
                                DailyPrice = model.DailyPrice,
                                ImageUrl = model.ImageUrl,
                                ColorName = color.Name,
                                CarState = car.CarState
                            };

          return result.ToListAsync();
        }

        public CarDetailDto GetCarDetailToRental(int id)
        {
            IQueryable<CarDetailDto> result =
                            from car in Context.Cars
                            join model in Context.Models on car.ModelId equals model.Id
                            join brand in Context.Brands on model.BrandId equals brand.Id
                            join color in Context.Colors on car.ColorId equals color.Id
                            join city in Context.Cities on car.CityId equals city.Id
                            where car.Id == id
                            select new CarDetailDto { 
                                CarId = car.Id, 
                                BrandName = brand.Name, 
                                ModelName = model.Name, 
                                CityName = city.Name, 
                                Color = color.Name, 
                                Plate = car.Plate, 
                                DailyPrice = model.DailyPrice
                            
                            };

            if (result.Any()) return result.First();
            else throw new BusinessException(Message.CarNotExists);
        }
    }
}
