using Application.Features.CorporateCustomer.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.CorporateCustomer.Models
{
    public class CorporateCustomerListModel : BasePageableModel
    {
        public IList<CorporateCustomerListDto> Items { get; set; }
    }
}
