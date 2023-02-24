using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Response
{
    public class InterviewStatusResponseModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
