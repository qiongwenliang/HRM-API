using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Entity
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        //Navigation Property
        public User User { get; set; }
        public Role Role { get; set; }

    }
}
