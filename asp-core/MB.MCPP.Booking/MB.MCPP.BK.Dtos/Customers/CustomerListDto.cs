using MB.MCPP.BK.Utils.Enums;

namespace MB.MCPP.BK.Dtos.Customers
{
    public class CustomerListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
    }
}
