using Application.Features.Color.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Color.Models
{
    public class ColorListModel : BasePageableModel
    {
        public IList<ColorListDto> Items { get; set; }
    }
}
