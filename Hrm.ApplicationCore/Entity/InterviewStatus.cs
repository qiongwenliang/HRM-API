using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Entity
{
    public class InterviewStatus
    {
        public int ID { get; set; }
        public string Type { get; set; }
        //Scheduled, resheduled, cancelled, finished
        public bool IsActive { get; set; }
    }
}
