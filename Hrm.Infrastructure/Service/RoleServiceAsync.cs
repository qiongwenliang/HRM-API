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
    public class RoleServiceAsync : IRoleServiceAsync
    {
        private readonly IRoleRepositoryAsync roleRepositoryAsync;
        public RoleServiceAsync(IRoleRepositoryAsync _roleRepositoryAsync)
        {
            roleRepositoryAsync = _roleRepositoryAsync;
        }

        public Task<int> AddRoleAsync(RoleRequestModel model)
        {
            Role role = new Role()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
            return roleRepositoryAsync.InsertAsync(role);
        }

        public Task<int> DeleteRoleAsync(int id)
        {
            return roleRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoleResponseModel>> GetAllRoleAsync()
        {
            var result = await roleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new RoleResponseModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                });
            }
            return null;
        }

        public async Task<RoleResponseModel> GetRoleByIdAsync(int id)
        {
            var result = await roleRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new RoleResponseModel()
                {
                    Name = result.Name,
                    Id = result.Id,
                    Description = result.Description
                };
            }
            return null;
        }

        public Task<int> UpdateRoleAsync(RoleRequestModel model)
        {
            Role role = new Role()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
            return roleRepositoryAsync.UpdateAsync(role);
        }
    }
}
