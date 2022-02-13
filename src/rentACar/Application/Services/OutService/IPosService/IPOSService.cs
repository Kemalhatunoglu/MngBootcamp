namespace Application.Services.OutService.IPosService
{
    public interface IPosService
    {
        Task PaymentConfirmation(float price);
    }
}
