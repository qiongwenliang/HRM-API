using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Entity
{
    public class EmployeeRole
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Position { get; set; }
        //Analyst, HR, Sales
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
