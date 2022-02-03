using Application.Constants;
using Application.Features.Color.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Color.Queries.GetColorList
{
    public class GetColorListQuery : IRequest<IDataResult<ColorListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetColorListQueryHandler : IRequestHandler<GetColorListQuery, IDataResult<ColorListModel>>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;

            public GetColorListQueryHandler(IMapper mapper, IColorRepository colorRepository)
            {
                _mapper = mapper;
                _colorRepository = colorRepository;
            }

            public async Task<IDataResult<ColorListModel>> Handle(GetColorListQuery request, CancellationToken cancellationToken)
            {
                var colors = await _colorRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedColor = _mapper.Map<ColorListModel>(colors);
                return new SuccessDataResult<ColorListModel>(mappedColor, Message.SuccessGet);
            }
        }
    }
}
