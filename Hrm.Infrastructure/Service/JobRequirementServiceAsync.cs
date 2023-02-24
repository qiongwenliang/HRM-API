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
    public class JobRequirementServiceAsync : IJobRequirementServiceAsync
    {
        private readonly IJobRequirementRepositoryAsync jobRequirementRepositoryAsync;
        public JobRequirementServiceAsync(IJobRequirementRepositoryAsync _jobRequirementRepositoryAsync)
        {
            jobRequirementRepositoryAsync = _jobRequirementRepositoryAsync;
        }

        public Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                TotalPositions = model.TotalPositions,
                PostingDate = model.PostingDate,
                ClosingDate = model.ClosingDate,
                JobCategoryId = model.JobCategoryId,
                IsActive = model.IsActive
            };
            return jobRequirementRepositoryAsync.InsertAsync(jobRequirement);
        }

        public Task<int> DeleteJobRequirementAsync(int id)
        {
            return jobRequirementRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementAsync()
        {
            var result = await jobRequirementRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new JobRequirementResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    TotalPositions = x.TotalPositions,
                    PostingDate = x.PostingDate,
                    ClosingDate = x.ClosingDate,
                    IsActive = x.IsActive,
                    JobCategoryId = x.JobCategoryId
                });
            }
            return null;
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var result = await jobRequirementRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new JobRequirementResponseModel()
                {
                    JobCategoryId = result.JobCategoryId,
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    PostingDate = result.PostingDate,
                    ClosingDate = result.ClosingDate,
                    TotalPositions = result.TotalPositions,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id = model.Id,
                Title = model.Title,
                JobCategoryId = model.JobCategoryId,
                Description = model.Description,
                PostingDate = model.PostingDate,
                ClosingDate = model.ClosingDate,
                TotalPositions = model.TotalPositions,
                IsActive = model.IsActive
            };
            return jobRequirementRepositoryAsync.UpdateAsync(jobRequirement);
        }
    }
}
