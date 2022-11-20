using AutoMapper;
using MB.MCPP.BK.Dtos.AddOns;
using MB.MCPP.BK.Entities;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class AddOnAutoMapperProfile : Profile
    {
        public AddOnAutoMapperProfile()
        {
            CreateMap<AddOn, AddOnDto>().ReverseMap();
        }
    }
}
