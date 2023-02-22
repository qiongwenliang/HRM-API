using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Entity
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Required]

        [Column(TypeName = "varchar(70)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? ResumeUrl { get; set; }
    }
}