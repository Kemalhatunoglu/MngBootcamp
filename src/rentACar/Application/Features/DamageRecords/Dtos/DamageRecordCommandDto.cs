namespace Application.Features.DamageRecords.Dtos
{
    public class DamageRecordCommandDto
    {
        public int? Id { get; set; }
        public int? CarId { get; set; }
        public string? DamageExp { get; set; }
    }
}
