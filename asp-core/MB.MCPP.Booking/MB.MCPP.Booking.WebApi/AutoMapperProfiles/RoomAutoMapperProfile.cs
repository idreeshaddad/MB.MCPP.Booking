using AutoMapper;
using MB.MCPP.BK.Dtos.Rooms;
using MB.MCPP.BK.Entities;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class RoomAutoMapperProfile : Profile
    {
        public RoomAutoMapperProfile()
        {
            CreateMap<Room, RoomDto>().ReverseMap();
        }
    }
}
