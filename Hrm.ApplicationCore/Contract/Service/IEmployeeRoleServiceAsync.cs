using Hrm.ApplicationCore.Model.Request;
using Hrm.ApplicationCore.Model.Response;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Contract.Service
{
    public interface IEmployeeRoleServiceAsync
    {
        Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model);
        Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model);
        Task<int> DeleteEmployeeRoleAsync(int id);
        Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id);
        Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoleAsync();
    }
}
