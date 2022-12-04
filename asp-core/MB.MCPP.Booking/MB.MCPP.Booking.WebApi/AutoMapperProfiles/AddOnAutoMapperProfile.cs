using AutoMapper;
using MB.MCPP.BK.Dtos.Addons;
using MB.MCPP.BK.Entities;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class AddonAutoMapperProfile : Profile
    {
        public AddonAutoMapperProfile()
        {
            CreateMap<Addon, AddonDto>().ReverseMap();
        }
    }
}
