using Hrm.ApplicationCore.Contract.Repository;
using Hrm.ApplicationCore.Entity;
using Hrm.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Infrastructure.Repository
{
    public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(HrmDbContext _context) : base(_context)
        {
        }
    }
}
