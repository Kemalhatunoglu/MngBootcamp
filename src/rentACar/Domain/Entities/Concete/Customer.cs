using Core.Persistence.Repositories;

namespace Domain.Entities.Concete
{
    public class Customer : Entity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public float FindeksRate { get; set; } = 100;

        public virtual ICollection<Rental> Rentals { get; set; }

        public Customer() => Rentals = new List<Rental>();

        public Customer(int id, string email, string phone, float findeksRate) : base(id)
        {
            Id = id;
            Email = email;
            Phone = phone;
            FindeksRate = findeksRate;
        }
    }
}
