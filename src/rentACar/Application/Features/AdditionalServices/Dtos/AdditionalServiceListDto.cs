namespace Application.Features.AdditionalServices.Dtos
{
    public class AdditionalServiceListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public int Count { get; set; }
    }
}
