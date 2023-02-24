using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Request
{
    public class EmployeeRoleRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
