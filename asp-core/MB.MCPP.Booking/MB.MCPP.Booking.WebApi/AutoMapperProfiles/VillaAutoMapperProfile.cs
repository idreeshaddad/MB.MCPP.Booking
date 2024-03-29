﻿using AutoMapper;
using MB.MCPP.BK.Dtos.Uploaders;
using MB.MCPP.BK.Dtos.Villas;
using MB.MCPP.BK.Entities.Addons;
using MB.MCPP.BK.Entities.Customers;
using MB.MCPP.BK.Entities.Villas;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class VillaAutoMapperProfile : Profile
    {
        public VillaAutoMapperProfile()
        {
            CreateMap<Villa, VillaDto>()
                .ForMember(dest => dest.AddonIds,
                            opts => opts.MapFrom(src => src.Addons.Select(a => a.Id)));

            CreateMap<VillaDto, Villa>();
            CreateMap<Villa, VillaDetailsDto>();
            CreateMap<Villa, VillaListDto>();
        }
    }
}
