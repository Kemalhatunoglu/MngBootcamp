using Application.Features.Fuel.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Fuel.Models
{
    public class FuelListModel : BasePageableModel
    {
        public IList<FuelListDto> Items { get; set; }
    }
}
