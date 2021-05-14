using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.ViewModels
{
    public class EmployeeModel : BaseEntityModel
    {
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public string MobileNo { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        public string Address { get; set; }




    }
    public enum GenderType
    {
        Male,
        Female
    }

}
