namespace Application.Services.OutService.AdditionalServices
{
    public interface IAdditionalService
    {
        Task<List<float>> GetAdditionalServicePriceList(List<int> additionalIdList, int rentalId);
        Task UpdateAdditionalServiceCount(int additionalId, bool isSelect);
        Task<List<float>> CalcAdditionalServicePrice(List<int> additionalIdList);
    }
}
