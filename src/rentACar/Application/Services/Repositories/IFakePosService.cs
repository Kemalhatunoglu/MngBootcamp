namespace Application.Services.Repositories
{
    public interface IFakePosService
    {
        Task Pay(string invoiceNo, decimal price);
    }
}
