using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concete
{
    public class Model : Entity
    {
        public Model()
        {
            Brand = new Brand();
        }

        public Model(int id, int brandId, int fuelId, int transmissionId, string name, double dailyPrice, string imageUrl) : this()
        {
            Id = id;
            BrandId = brandId;
            FuelId = fuelId;
            TransmissionId = transmissionId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
        }

        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual Fuel Fuel { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

    }
}
