using Application.Features.Cars.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Cars.Models
{
    public class CarListModel : BasePageableModel
    {
        public List<CarListDto> CarItems { get; set; }
    }
}
