using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Entity
{
    public class InterviewFeedback
    {
        public int Id { get; set; }
        public int InterviewID { get; set; }
        public string Description { get; set; }

        //navigational property
        public Interview Interview { get; set; }
    }
}
