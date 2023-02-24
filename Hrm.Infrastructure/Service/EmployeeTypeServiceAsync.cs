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
    public class EmployeeTypeServiceAsync : IEmployeeTypeServiceAsync
    {
        private readonly IEmployeeTypeRepositoryAsync employeeTypeRepositoryAsync;

        public EmployeeTypeServiceAsync(IEmployeeTypeRepositoryAsync _employeeTypeRepositoryAsync)
        {
            employeeTypeRepositoryAsync = _employeeTypeRepositoryAsync;
        }

        public Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            EmployeeType employeeType = new EmployeeType()
            {
                Id = model.Id,
                Type = model.Type,
                IsActive = model.IsActive,
            };
            return employeeTypeRepositoryAsync.InsertAsync(employeeType);
        }

        public Task<int> DeleteEmployeeTypeAsync(int id)
        {
            return employeeTypeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypeAsync()
        {
            var result = await employeeTypeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeTypeResponseModel()
                { Id = x.Id, Type = x.Type, IsActive = x.IsActive });
            }
            return null;
        }

        public async Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id)
        {
            var result = await employeeTypeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeTypeResponseModel()
                {
                    Id = result.Id,
                    Type = result.Type,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            EmployeeType employeeType = new EmployeeType()
            {
                Id = model.Id,
                Type = model.Type,
                IsActive = model.IsActive
            };
            return employeeTypeRepositoryAsync.UpdateAsync(employeeType);
        }
    }
}
