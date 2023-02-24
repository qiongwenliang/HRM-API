using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Request
{
    public class EmployeeTypeRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Type is required")]

        public string Type { get; set; }

        public bool IsActive { get; set; }
    }
}
