using MB.MCPP.BK.Utils.Enums;
using Microsoft.AspNetCore.Http;
using System;
namespace MB.MCPP.BK.Dtos.Customers
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public string ImageName { get; set; }
    }
}
