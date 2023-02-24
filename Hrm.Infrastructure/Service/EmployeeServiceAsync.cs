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
    public class EmployeeServiceAsync : IEmployeeServiceAsync
    {

        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;

        public EmployeeServiceAsync(IEmployeeRepositoryAsync _employeeRepositoryAsync)
        {
            employeeRepositoryAsync = _employeeRepositoryAsync;
        }


        public Task<int> AddEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                DateOfBirth = model.DateOfBirth,
                SSN = model.SSN,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                EmployeeRoleId = model.EmployeeRoleId,
                EmployeeStatusId = model.EmployeeStatusId,
                EmployeeTypeId = model.EmployeeTypeId
            };
            return employeeRepositoryAsync.InsertAsync(employee);
        }

        public Task<int> DeleteEmployeeAsync(int id)
        {
            return employeeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeeAsync()
        {
            var result = await employeeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeResponseModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailAddress = x.EmailAddress,
                    DateOfBirth = x.DateOfBirth,
                    SSN = x.SSN,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    EmployeeRoleId = x.EmployeeRoleId,
                    EmployeeStatusId = x.EmployeeStatusId,
                    EmployeeTypeId = x.EmployeeTypeId
                });
            }
            return null;
        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var result = await employeeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    EmailAddress = result.EmailAddress,
                    DateOfBirth = result.DateOfBirth,
                    SSN = result.SSN,
                    Address = result.Address,
                    PhoneNumber = result.PhoneNumber,
                    EmployeeRoleId = result.EmployeeRoleId,
                    EmployeeStatusId = result.EmployeeStatusId,
                    EmployeeTypeId = result.EmployeeTypeId
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                DateOfBirth = model.DateOfBirth,
                SSN = model.SSN,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                EmployeeRoleId = model.EmployeeRoleId,
                EmployeeStatusId = model.EmployeeStatusId,
                EmployeeTypeId = model.EmployeeTypeId
            };
            return employeeRepositoryAsync.UpdateAsync(employee);
        }
    }
}
