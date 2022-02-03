﻿using Application.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        //Gerkhin Language
        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _brandRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any())
                throw new BusinessException(Message.ExistingData);
        }
    }
}
