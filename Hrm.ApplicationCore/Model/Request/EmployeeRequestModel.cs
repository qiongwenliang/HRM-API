using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Request
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "SSN is required")]
        public int SSN { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        public int EmployeeRoleId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int EmployeeStatusId { get; set; }
    }
}
