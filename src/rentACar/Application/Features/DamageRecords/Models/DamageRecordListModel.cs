using Application.Features.DamageRecords.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.DamageRecords.Models
{
    public class DamageRecordListModel : BasePageableModel
    {
        public IList<DamageRecordListDto> Items { get; set; }
    }
}
