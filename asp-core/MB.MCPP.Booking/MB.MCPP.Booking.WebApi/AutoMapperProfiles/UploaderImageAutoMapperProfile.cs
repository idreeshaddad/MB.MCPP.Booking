using AutoMapper;
using MB.MCPP.BK.Dtos.Uploaders;
using MB.MCPP.BK.Entities.Addons;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class UploaderImageAutoMapperProfile : Profile
    {
        public UploaderImageAutoMapperProfile()
        {
            CreateMap<AddonImage, UploaderImageDto>();
        }
    }
}
