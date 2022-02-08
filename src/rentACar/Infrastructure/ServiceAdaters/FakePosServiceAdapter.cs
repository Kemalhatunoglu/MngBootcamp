using Application.Services.Repositories;

namespace Infrastructure.ServiceAdaters
{
    public class FakePosServiceAdapter : IFakePosService
    {
        public Task Pay(string invoiceNo, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
