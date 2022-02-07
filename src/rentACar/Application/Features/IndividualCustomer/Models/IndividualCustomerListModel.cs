using Application.Features.IndividualCustomer.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.IndividualCustomer.Models
{
    public class IndividualCustomerListModel : BasePageableModel
    {
        public IList<IndividualCustomerListDto> Items { get; set; }
    }
}
