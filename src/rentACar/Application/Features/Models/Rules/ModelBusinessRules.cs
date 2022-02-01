using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Rules
{
    public class ModelBusinessRules
    {
        private readonly IModelRepository _modelRepository;

        public ModelBusinessRules(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task ModelNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _modelRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any())
                throw new BusinessException("Model name exists");
        }

        public void ModelDailyPriceCanNotBeLessThanZero(double price)
        {
            if (price < 0)
                throw new BusinessException("Model daily price can't be less than zero");
        }

    }
}
