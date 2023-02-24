using Hrm.ApplicationCore.Contract.Repository;
using Hrm.ApplicationCore.Contract.Service;
using Hrm.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Infrastructure.Service
{
    public class EmployeeRoleServiceAsync : IEmployeeRoleServiceAsync
    {

        private readonly IEmployeeRoleRepositoryAsync employeeRoleRepositoryAsync;

        public EmployeeRoleServiceAsync(IEmployeeRoleRepositoryAsync _employeeRoleRespository)
        {
            employeeRoleRepositoryAsync = _employeeRoleRespository;
        }


        public Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            EmployeeRole employeerole = new EmployeeRole()
            {
                Position = model.Position,
                Description = model.Description,
                IsActive = model.IsActive,
            };
            return employeeRoleRepositoryAsync.InsertAsync(employeerole);
        }

        public Task<int> DeleteEmployeeRoleAsync(int id)
        {
            return employeeRoleRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoleAsync()
        {
            var result = await employeeRoleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeRoleResponseModel()
                {
                    Id = x.Id,
                    Position = x.Position,
                    Description = x.Description,
                    IsActive = x.IsActive
                });
            }
            return null;
        }

        public async Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id)
        {
            var result = await employeeRoleRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeRoleResponseModel()
                {
                    Id = result.Id,
                    Position = result.Position,
                    Description = result.Description,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            EmployeeRole employeeRole = new EmployeeRole()
            {
                Id = model.Id,
                Position = model.Position,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return employeeRoleRepositoryAsync.UpdateAsync(employeeRole);
        }
    }
}
