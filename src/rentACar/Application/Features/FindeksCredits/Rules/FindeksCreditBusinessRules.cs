using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.FindeksCredits.Rules
{
    public class FindeksCreditBusinessRules
    {
        private readonly IFindeksCreditRepository _findeksCreditRepository;

        public FindeksCreditBusinessRules(IFindeksCreditRepository findeksCreditRepository)
        {
            _findeksCreditRepository = findeksCreditRepository;
        }

        public async Task FindeksCreditMustBeEnough(int findexId)
        {
            var result = await _findeksCreditRepository.GetAsync(x => x.Id == findexId);
            if (result == null) throw new BusinessException(Message.FindeksIsNotExist);
        }
    }
}
