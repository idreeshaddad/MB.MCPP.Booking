using AutoMapper;
using MB.MCPP.BK.Dtos.Villas;
using MB.MCPP.BK.Entities;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class VillaAutoMapperProfile : Profile
    {
        public VillaAutoMapperProfile()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
        }
    }
}
