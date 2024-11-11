using AutoMapper;
using WiFiSharing.Application.DTOs;
using WiFiSharing.Domain.Entities;

namespace WiFiSharing.Infrastructure.Mappings
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Favorite, FavoriteDto>();
            CreateMap<FavoriteDto, Favorite>();
            CreateMap<Admin, AdminDto>();
            CreateMap<AdminDto,Admin>();
            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>();
            CreateMap<Reputation, ReputationDto>();
            CreateMap<ReputationDto, Reputation>();
            CreateMap<WiFiNetwork, WiFiNetworkDto>();
            CreateMap<IEnumerable<WiFiNetwork>, IEnumerable<WiFiNetworkDto>>();
            CreateMap<WiFiNetworkDto, WiFiNetwork>();
        }
    }
}
