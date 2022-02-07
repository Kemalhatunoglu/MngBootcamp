using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities.Concete
{
    public class FindeksCredit : Entity
    {
        public int CustomerId { get; set; }
        public float Score { get; set; } = 1900;
        public CustomerType CustomerType { get; set; }

        public FindeksCredit()
        {

        }

        public FindeksCredit(int id, int customerId, float score, CustomerType customerType) : base(id)
        {
            CustomerId = customerId;
            Score = score;
            CustomerType = customerType;
        }
    }
}
