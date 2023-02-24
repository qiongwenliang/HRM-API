using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Request
{
    public class InterviewStatusRequestModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
