using Core.Persistence.Repositories;

namespace Domain.Entities.Concete
{
    public class AdditionalService : Entity
    {
        public AdditionalService()
        {

        }

        public AdditionalService(int id, float dailyPrice, int count) : base(id)
        {
            Id = id;
            DailyPrice = dailyPrice;
            Count = count;
        }

        public string Name { get; set; }
        public float DailyPrice { get; set; }
        public int Count { get; set; }
    }
}
