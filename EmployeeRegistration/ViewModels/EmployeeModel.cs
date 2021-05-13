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

        [Required(ErrorMessage = "Enter valid email address")]
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
