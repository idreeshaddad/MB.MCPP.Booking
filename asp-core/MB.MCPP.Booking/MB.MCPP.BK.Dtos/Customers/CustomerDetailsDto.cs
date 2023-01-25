using MB.MCPP.BK.Dtos.Uploaders;
using MB.MCPP.BK.Utils.Enums;
using System;
namespace MB.MCPP.BK.Dtos.Customers
{
    public class CustomerDetailsDto
    {
        public CustomerDetailsDto()
        {
            Images = new List<UploaderImageDto>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public List<UploaderImageDto> Images { get; set; }

    }
}
