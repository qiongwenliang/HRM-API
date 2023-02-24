using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Entity
{
    public class EmployeeStatus
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Type { get; set; }
        //Working, Left, Terminate
        [Column(TypeName = "varchar(500)")]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
