using MB.MCPP.BK.Utils.Enums;
using System;
namespace MB.MCPP.BK.Dtos.Customers
{
    public class CustomerDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
    }
}
