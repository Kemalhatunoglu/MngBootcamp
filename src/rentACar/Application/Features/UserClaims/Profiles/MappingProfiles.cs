using Application.Features.UserClaims.Commands.CreateUserClaims;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.UserClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        }
    }
}
