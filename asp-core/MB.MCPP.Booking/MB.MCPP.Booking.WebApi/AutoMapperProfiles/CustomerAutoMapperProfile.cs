using AutoMapper;
using MB.MCPP.BK.Dtos.Customers;
using MB.MCPP.BK.Entities.Customers;

namespace MB.MCPP.BK.WebApi.AutoMapperProfiles
{
    public class CustomerAutoMapperProfile : Profile
    {
        public CustomerAutoMapperProfile()
        {
            CreateMap<Customer, CustomerListDto>();
            CreateMap<Customer, CustomerDetailsDto>();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
