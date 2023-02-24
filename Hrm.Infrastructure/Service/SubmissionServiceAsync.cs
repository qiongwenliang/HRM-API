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
    public class SubmissionServiceAsync : ISubmissionServiceAsync
    {

        private readonly ISubmissionRepositoryAsync submissionRepositoryAsync;
        public SubmissionServiceAsync(ISubmissionRepositoryAsync _submissionRepositoryAsync)
        {
            submissionRepositoryAsync = _submissionRepositoryAsync;
        }

        public Task<int> AddSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                Id = model.Id,
                CandidateId = model.CandidateId,
                JobRequirementId = model.JobRequirementId,
                AppliedOn = model.AppliedOn
            };
            return submissionRepositoryAsync.InsertAsync(submission);
        }

        public Task<int> DeleteSubmissionAsync(int id)
        {
            return submissionRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionAsync()
        {
            var result = await submissionRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new SubmissionResponseModel()
                {
                    Id = x.Id,
                    JobRequirementId = x.JobRequirementId,
                    CandidateId = x.CandidateId,
                    AppliedOn = x.AppliedOn
                });
            }
            return null;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            var result = await submissionRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new SubmissionResponseModel()
                {
                    Id = result.Id,
                    JobRequirementId = result.JobRequirementId,
                    CandidateId = result.CandidateId,
                    AppliedOn = result.AppliedOn
                };
            }
            return null;
        }

        public Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                Id = model.Id,
                AppliedOn = model.AppliedOn,
                JobRequirementId = model.JobRequirementId,
                CandidateId = model.CandidateId
            };
            return submissionRepositoryAsync.UpdateAsync(submission);
        }
    }
}
