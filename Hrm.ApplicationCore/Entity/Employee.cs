using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        public int SSN { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int EmployeeRoleId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int EmployeeStatusId { get; set; }

        //Navigational Property
        public EmployeeRole EmployeeRole { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }
}
