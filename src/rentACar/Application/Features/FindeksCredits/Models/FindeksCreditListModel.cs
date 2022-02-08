using Application.Features.FindeksCredits.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.FindeksCredits.Models
{
    public class FindeksCreditListModel : BasePageableModel
    {
        public IList<FindeksCreditListDto> Items { get; set; }
    }
}
