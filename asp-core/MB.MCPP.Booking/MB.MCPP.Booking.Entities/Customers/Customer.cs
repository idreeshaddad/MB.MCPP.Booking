using MB.MCPP.BK.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MB.MCPP.BK.Entities.Customers
{
    public class Customer
    {
        public Customer()
        {
            Images = new List<CustomerImage>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public List<CustomerImage> Images { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DOB.Year;
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
