using MB.MCPP.BK.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MB.MCPP.BK.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public string? ImageName { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DOB.Year;
            }
        }

        [NotMapped]
        public string FullName { 
            get
            {
                return $"{FirstName} {LastName}";
            } 
        }
    }
}
