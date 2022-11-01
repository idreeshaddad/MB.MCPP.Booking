using MB.MCPP.BK.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MB.MCPP.BK.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }

        [NotMapped]
        public int Age { get; set; }
    }
}
