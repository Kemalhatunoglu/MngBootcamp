using Application.Services.OutService.AdditionalServices;
using Application.Services.Repositories;
using Domain.Entities.Concete;

namespace Application.Services.OutService.Invoices
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IAdditionalService _additionalService;

        public InvoiceManager(IInvoiceRepository invoiceRepository, IAdditionalService additionalService)
        {
            _invoiceRepository = invoiceRepository;
            _additionalService = additionalService;
        }

        public async Task<bool> AddInvoiceAsync(Invoice invoice)
        {
            var addedInvoice = await _invoiceRepository.AddAsync(invoice);
            if (addedInvoice != null) return true;
            return false;
        }

        public Task<Invoice> CreateInvoice(Rental rental, float dailyPrice, List<float>? additional)
        {
            short totalRentalDate = Convert.ToInt16(rental.EndDate.Day - rental.StartDate.Day > 0 ? rental.EndDate.Day - rental.StartDate.Day : 1);

            float totalFee = (float)(dailyPrice * totalRentalDate);
            if (rental.DeliveryCityId != rental.RentedCityId) totalFee += 500;

            if (additional != null)
            {
                additional.ForEach(x =>
                {
                    totalFee += x;
                });
            }

            var invoiceNumber = new Random();
            Invoice newInvoice = new()
            {
                CustomerId = rental.CustomerId,
                InvoiceNo = String.Format("KML{0:000000}", invoiceNumber.Next(0, 1000)),
                CreationDate = DateTime.Now,
                RentalStartDate = rental.StartDate,
                RentalEndDate = rental.EndDate,
                TotalFee = totalFee
            };

            return Task.FromResult(newInvoice);
        }

        public async Task UpdateInvoiceWithAdditional(Invoice invoice, List<float> additional)
        {
            for (int i = 0; i < additional.Count; i++)
            {
                invoice.TotalFee += additional[i];
            }

            await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task<float> CalcTotalPrice(Rental rental, float dailyPrice, List<int>? additionalIdList)
        {
            short totalRentalDate = Convert.ToInt16(rental.EndDate.Day - rental.StartDate.Day > 0 ? rental.EndDate.Day - rental.StartDate.Day : 1);
            var total = await _additionalService.CalcAdditionalServicePrice(additionalIdList);

            float totalFee = (float)(dailyPrice * totalRentalDate);
            if (rental.DeliveryCityId != rental.RentedCityId) totalFee += 500;
            if (total != null)
            {
                additionalIdList.ForEach(x =>
                {
                    totalFee += x;
                });
            }

            return totalFee;
        }
    }
}
