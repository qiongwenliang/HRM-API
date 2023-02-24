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
    public class InterviewServiceAsync : IInterviewServiceAsync
    {
        private readonly IInterviewRepositoryAsync interviewRepositoryAsync;
        public InterviewServiceAsync(IInterviewRepositoryAsync _interviewRepositoryAsync)
        {
            interviewRepositoryAsync = _interviewRepositoryAsync;
        }

        public Task<int> AddInterviewAsync(InterviewRequestModel model)
        {
            Interview interview = new Interview()
            {
                Id = model.Id,
                SubmissionId = model.SubmissionId,
                InterviewDate = model.InterviewDate,
                InterviewRound = model.InterviewRound,
                InterviewTypeID = model.InterviewTypeID,
                InterviewStatusID = model.InterviewStatusID
            };
            return interviewRepositoryAsync.InsertAsync(interview);
        }

        public Task<int> DeleteInterviewAsync(int id)
        {
            return interviewRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewResponseModel>> GetAllInterviewAsync()
        {
            var result = await interviewRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewResponseModel()
                {
                    InterviewDate = x.InterviewDate,
                    Id = x.Id,
                    InterviewRound = x.InterviewRound,
                    SubmissionId = x.SubmissionId,
                    InterviewStatusID = x.InterviewStatusID,
                    InterviewTypeID = x.InterviewTypeID,
                });
            }
            return null;
        }

        public async Task<InterviewResponseModel> GetInterviewByIdAsync(int id)
        {
            var result = await interviewRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewResponseModel()
                {
                    Id = result.Id,
                    InterviewDate = result.InterviewDate,
                    InterviewRound = result.InterviewRound,
                    SubmissionId = result.SubmissionId,
                    InterviewStatusID = result.InterviewStatusID,
                    InterviewTypeID = result.InterviewTypeID,
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewAsync(InterviewRequestModel model)
        {
            Interview interview = new Interview()
            {
                Id = model.Id,
                InterviewTypeID = model.InterviewTypeID,
                InterviewStatusID = model.InterviewStatusID,
                InterviewDate = model.InterviewDate,
                InterviewRound = model.InterviewRound,
                SubmissionId = model.SubmissionId,
            };
            return interviewRepositoryAsync.UpdateAsync(interview);
        }
    }
}
