using AutoMapper;
using MB.MCPP.BK.Dtos.Uploaders;
using MB.MCPP.BK.Entities.Addons;
using MB.MCPP.BK.Entities.Customers;
using MB.MCPP.BK.Entities.Villas;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class UploaderImageAutoMapperProfile : Profile
    {
        public UploaderImageAutoMapperProfile()
        {
            CreateMap<UploaderImageDto, AddonImage>().ReverseMap();
            CreateMap<UploaderImageDto, VillaImage>().ReverseMap();
            CreateMap<UploaderImageDto, CustomerImage>().ReverseMap();
        }
    }
}
