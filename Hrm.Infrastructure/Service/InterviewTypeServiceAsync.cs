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
    public class InterviewTypeServiceAsync : IInterviewTypeServiceAsync
    {
        private readonly IInterviewTypeRepositoryAsync interviewTypeRepositoryAsync;
        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync _interviewTypeRepositoryAsync)
        {
            interviewTypeRepositoryAsync = _interviewTypeRepositoryAsync;
        }

        public Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Id = model.Id,
                Type = model.Type,
                IsActive = model.IsActive,
            };
            return interviewTypeRepositoryAsync.InsertAsync(interviewType);
        }

        public Task<int> DeleteInterviewTypeAsync(int id)
        {
            return interviewTypeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypeAsync()
        {
            var result = await interviewTypeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewTypeResponseModel()
                {
                    Type = x.Type,
                    Id = x.Id,
                    IsActive = x.IsActive
                });
            }
            return null;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {
            var result = await interviewTypeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewTypeResponseModel()
                {
                    Id = result.Id,
                    Type = result.Type,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Id = model.Id,
                Type = model.Type,
                IsActive = model.IsActive
            };
            return interviewTypeRepositoryAsync.UpdateAsync(interviewType);
        }
    }
}
