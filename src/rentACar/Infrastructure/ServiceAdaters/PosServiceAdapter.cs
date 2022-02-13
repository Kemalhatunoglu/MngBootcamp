using Application.Constants;
using Application.Services.OutService.IPosService;
using Core.CrossCuttingConcerns.Exceptions;

namespace Infrastructure.ServiceAdaters
{
    public class PosServiceAdapter : IPosService
    {
        public async Task PaymentConfirmation(float price)
        {
            Random random = new();
            bool result = Convert.ToBoolean(random.Next(2));
            if (!result) throw new BusinessException(Message.PaymentError);
        }
    }
}
