using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Entity
{
    public class InterviewType
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Type { get; set; }
        //eg, phone, inperson, zoom, MS Team
        public bool IsActive { get; set; }
    }
}
