using AutoMapper;
using MB.MCPP.BK.Dtos.Bookings;
using MB.MCPP.BK.Entities;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class BookingAutoMapperProfile : Profile
    {
        public BookingAutoMapperProfile()
        {
            CreateMap<Booking, BookingListDto>();
            CreateMap<Booking, BookingDto>().ReverseMap();
        }
    }
}
