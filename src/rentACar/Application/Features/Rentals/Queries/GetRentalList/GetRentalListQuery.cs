using Application.Constants;
using Application.Features.Rentals.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using MediatR;

namespace Application.Features.Rentals.Queries.GetRentalList
{
    public class GetRentalListQuery : IRequest<IDataResult<RentalListModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetRentalListQueryHandler : IRequestHandler<GetRentalListQuery, IDataResult<RentalListModel>>
        {
            private readonly IRentalRepository _rentalRepository;
            private readonly IMapper _mapper;

            public GetRentalListQueryHandler(IMapper mapper, IRentalRepository rentalRepository)
            {
                _mapper = mapper;
                _rentalRepository = rentalRepository;
            }

            public async Task<IDataResult<RentalListModel>> Handle(GetRentalListQuery request, CancellationToken cancellationToken)
            {
                var rentals = await _rentalRepository.GetListAsync(
                   index: request.PageRequest.Page,
                   size: request.PageRequest.PageSize
                   );
                var mappedRental = _mapper.Map<RentalListModel>(rentals);

                return new SuccessDataResult<RentalListModel>(mappedRental, Message.SuccessGet);
            }
        }
    }
}
