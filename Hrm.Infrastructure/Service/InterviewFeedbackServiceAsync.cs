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
    public class InterviewFeedbackServiceAsync : IInterviewFeedbackServiceAsync
    {

        private readonly IInterviewFeedbackRepositoryAsync interviewFeedbackRepositoryAsync;
        public InterviewFeedbackServiceAsync(IInterviewFeedbackRepositoryAsync _interviewFeedbackRepositoryAsync)
        {
            interviewFeedbackRepositoryAsync = _interviewFeedbackRepositoryAsync;
        }


        public Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            InterviewFeedback interviewFeedback = new InterviewFeedback()
            {
                Id = model.Id,
                InterviewID = model.InterviewID,
                Description = model.Description
            };
            return interviewFeedbackRepositoryAsync.InsertAsync(interviewFeedback);
        }

        public Task<int> DeleteInterviewFeedbackAsync(int id)
        {
            return interviewFeedbackRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbackAsync()
        {
            var result = await interviewFeedbackRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewFeedbackResponseModel()
                {
                    Id = x.Id,
                    InterviewID = x.InterviewID,
                    Description = x.Description
                });
            }
            return null;
        }

        public async Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id)
        {
            var result = await interviewFeedbackRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewFeedbackResponseModel()
                {
                    Id = result.Id,
                    InterviewID = result.InterviewID,
                    Description = result.Description
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            InterviewFeedback interviewFeedback = new InterviewFeedback()
            {
                Id = model.InterviewID,
                InterviewID = model.Id,
                Description = model.Description
            };
            return interviewFeedbackRepositoryAsync.UpdateAsync(interviewFeedback);
        }
    }
}
