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
    public class InterviewStatusServiceAsync : IInterviewStatusServiceAsync
    {
        private readonly IInterviewStatusRepositoryAsync interviewStatusRepositoryAsync;
        public InterviewStatusServiceAsync(IInterviewStatusRepositoryAsync _interviewStatusRepositoryAsync)
        {
            interviewStatusRepositoryAsync = _interviewStatusRepositoryAsync;
        }

        public Task<int> AddInterviewStatusAsync(InterviewStatusRequestModel model)
        {
            InterviewStatus interviewStatus = new InterviewStatus()
            {
                ID = model.ID,
                Type = model.Type,
                IsActive = model.IsActive,
            };
            return interviewStatusRepositoryAsync.InsertAsync(interviewStatus);
        }

        public Task<int> DeleteInterviewStatusAsync(int id)
        {
            return interviewStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewStatusResponseModel>> GetAllInterviewStatusAsync()
        {
            var result = await interviewStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewStatusResponseModel()
                {
                    ID = x.ID,
                    Type = x.Type,
                    IsActive = x.IsActive
                });
            }
            return null;
        }

        public async Task<InterviewStatusResponseModel> GetInterviewStatusByIdAsync(int id)
        {
            var result = await interviewStatusRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewStatusResponseModel()
                {
                    ID = result.ID,
                    Type = result.Type,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewStatusAsync(InterviewStatusRequestModel model)
        {
            InterviewStatus interviewStatus = new InterviewStatus()
            {
                ID = model.ID,
                Type = model.Type,
                IsActive = model.IsActive
            };
            return interviewStatusRepositoryAsync.UpdateAsync(interviewStatus);
        }
    }
}
