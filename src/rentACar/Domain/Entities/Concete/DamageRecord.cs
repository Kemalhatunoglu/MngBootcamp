using Core.Persistence.Repositories;

namespace Domain.Entities.Concete
{
    public class DamageRecord : Entity
    {
        public int CarId { get; set; }
        public string DamageExp { get; set; }

        public virtual Car Car { get; set; }

        public DamageRecord()
        {

        }

        public DamageRecord(int id, int carId, string damageExp)
        {
            Id = id;
            CarId = carId;
            DamageExp = damageExp;
        }
    }
}
