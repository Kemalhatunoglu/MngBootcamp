using Domain.Enums;

namespace Application.Features.FindeksCredits.Dtos
{
    public class FindeksCreditListDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public float Score { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
