using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IUserRoleServiceAsync
    {
        Task<int> AddUserRoleAsync(UserRoleRequestModel model);
        Task<int> UpdateUserRoleAsync(UserRoleRequestModel model);
        Task<int> DeleteUserRoleAsync(int id);
        Task<UserRoleResponseModel> GetUserRoleByIdAsync(int id);
        Task<IEnumerable<UserRoleResponseModel>> GetAllUserRoleAsync();
    }
}
