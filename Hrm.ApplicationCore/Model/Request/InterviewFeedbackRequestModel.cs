using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Request
{
    public class InterviewFeedbackRequestModel
    {
        public int Id { get; set; }
        public int InterviewID { get; set; }
        public string Description { get; set; }
    }
}
