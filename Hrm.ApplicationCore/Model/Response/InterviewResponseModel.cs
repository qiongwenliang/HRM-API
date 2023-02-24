using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Response
{
    public class InterviewResponseModel
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public DateTime InterviewDate { get; set; }
        public int InterviewRound { get; set; }
        public int InterviewTypeID { get; set; }
        public int InterviewStatusID { get; set; }
    }
}
