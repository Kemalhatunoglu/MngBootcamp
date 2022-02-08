using Core.Persistence.Repositories;

namespace Domain.Entities.Concete
{
    public class City : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public City()
        {
            Cars = new HashSet<Car>();
        }

        public City(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
