using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Response
{
    public class EmployeeRoleResponseModel
    {
        public int Id { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
