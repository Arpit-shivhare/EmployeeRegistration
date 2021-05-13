using System;
using System.Collections.Generic;
using System.Text;

namespace _Core.Domain
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }






    }
    public enum GenderType
    {
        Male,
        Female
    }

}
