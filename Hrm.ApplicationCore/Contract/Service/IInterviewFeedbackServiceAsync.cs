using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface IInterviewFeedbackServiceAsync
    {
        Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model);
        Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model);
        Task<int> DeleteInterviewFeedbackAsync(int id);
        Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id);
        Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbackAsync();
    }
}



