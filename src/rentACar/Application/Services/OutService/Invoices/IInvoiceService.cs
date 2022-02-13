using Domain.Entities.Concete;

namespace Application.Services.OutService.Invoices
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateInvoice(Rental rental, float dailyPrice, List<float>? additional);
        Task UpdateInvoiceWithAdditional(Invoice invoice, List<float> additional);
        Task<bool> AddInvoiceAsync(Invoice invoice);
        Task<float> CalcTotalPrice(Rental rental, float dailyPrice, List<int>? additionalIdList);
    }
}
