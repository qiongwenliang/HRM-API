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
    public class UserServiceAsync : IUserServiceAsync
    {
        private readonly IUserRepositoryAsync userRepositoryAsync;

        public UserServiceAsync(IUserRepositoryAsync _userRepositoryAsync)
        {
            userRepositoryAsync = _userRepositoryAsync;
        }

        public Task<int> AddUserAsync(UserRequestModel model)
        {
            User user = new User()
            {
                UserName = model.UserName,
                Id = model.Id,
                EmailId = model.EmailId,
                Password = model.Password
            };
            return userRepositoryAsync.InsertAsync(user);
        }

        public Task<int> DeleteUserAsync(int id)
        {
            return userRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUserAsync()
        {
            var result = await userRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new UserResponseModel()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    EmailId = x.EmailId,
                    Password = x.Password
                });
            }
            return null;
        }

        public async Task<UserResponseModel> GetUserByIdAsync(int id)
        {
            var result = await userRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new UserResponseModel()
                {
                    Id = result.Id,
                    UserName = result.UserName,
                    EmailId = result.EmailId,
                    Password = result.Password
                };
            }
            return null;
        }

        public Task<int> UpdateUserAsync(UserRequestModel model)
        {
            User user = new User()
            {
                Id = model.Id,
                UserName = model.UserName,
                EmailId = model.EmailId,
                Password = model.Password
            };
            return userRepositoryAsync.UpdateAsync(user);
        }
    }
}
