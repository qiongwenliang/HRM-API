using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Entity
{
    public class Interview
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        [DataType(DataType.DateTime)]
        public DateTime InterviewDate { get; set; }
        public int InterviewRound { get; set; }
        public int InterviewTypeID { get; set; }
        public int InterviewStatusID { get; set; }

        //Navigation Property
        public Submission Submission { get; set; }
        public InterviewType InterviewType { get; set; }
        public InterviewStatus InterviewStatus { get; set; }
    }
}
