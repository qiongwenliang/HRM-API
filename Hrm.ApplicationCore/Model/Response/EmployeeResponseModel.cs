using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Response
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string DateOfBirth { get; set; }
        public int SSN { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int EmployeeRoleId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int EmployeeStatusId { get; set; }
    }
}
