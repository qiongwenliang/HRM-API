using Hrm.ApplicationCore.Contract.Repository;
using Hrm.ApplicationCore.Entity;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Infrastructure.Service
{
    public class EmployeeStatusServiceAsync : IEmployeeStatusServiceAsync
    {
        private readonly IEmployeeStatusRepositoryAsync employeeStatusRepositoryAsync;

        public EmployeeStatusServiceAsync(IEmployeeStatusRepositoryAsync _employeeStatusRepositoryAsync)
        {
            employeeStatusRepositoryAsync = _employeeStatusRepositoryAsync;
        }

        public Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus employeeStatus = new EmployeeStatus()
            {
                Id = model.Id,
                Type = model.Type,
                Description = model.Description,
                IsActive = model.IsActive,
            };
            return employeeStatusRepositoryAsync.InsertAsync(employeeStatus);
        }

        public Task<int> DeleteEmployeeStatusAsync(int id)
        {
            return employeeStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatusAsync()
        {
            var result = await employeeStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeStatusResponseModel()
                {
                    Id = x.Id,
                    Type = x.Type,
                    Description = x.Description,
                    IsActive = x.IsActive
                });
            }
            return null;
        }

        public async Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id)
        {
            var result = await employeeStatusRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeStatusResponseModel()
                {
                    Id = result.Id,
                    Type = result.Type,
                    Description = result.Description,
                    IsActive = result.IsActive,
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus employeeRole = new EmployeeStatus()
            {
                Id = model.Id,
                Type = model.Type,
                Description = model.Description,
                IsActive = model.IsActive,
            };
            return employeeStatusRepositoryAsync.UpdateAsync(employeeRole);
        }
    }
}
