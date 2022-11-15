using AutoMapper;
using MB.MCPP.BK.Dtos.RoomServices;
using MB.MCPP.BK.Entities;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class RoomServiceAutoMapperProfile : Profile
    {
        public RoomServiceAutoMapperProfile()
        {
            CreateMap<RoomService, RoomServiceDto>().ReverseMap();
        }
    }
}
