using Application.Features.Cities.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Cities.Models
{
    public class CityListModel : BasePageableModel
    {
        public IList<CityListDto> Items { get; set; }
    }
}
