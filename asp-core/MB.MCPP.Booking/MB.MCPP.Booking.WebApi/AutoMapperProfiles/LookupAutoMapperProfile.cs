using AutoMapper;
using MB.MCPP.BK.Dtos.Lookups;
using MB.MCPP.BK.Entities;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class LookupAutoMapperProfile: Profile
    {
        public LookupAutoMapperProfile()
        {
            CreateMap<AddOn, LookupDto>();
        }
    }
}
