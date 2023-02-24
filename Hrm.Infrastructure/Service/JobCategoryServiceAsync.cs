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
    public class JobCategoryServiceAsync : IJobCategoryServiceAsync
    {
        private readonly IJobCategoryRepositoryAsync jobCategoryRepositoryAsync;
        public JobCategoryServiceAsync(IJobCategoryRepositoryAsync _jobCategoryRepositoryAsync)
        {
            jobCategoryRepositoryAsync = _jobCategoryRepositoryAsync;
        }

        public Task<int> AddJobCategoryAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory()
            {
                Name = model.Name,
                Id = model.Id,
                IsActive = model.IsActive
            };
            return jobCategoryRepositoryAsync.InsertAsync(jobCategory);
        }

        public Task<int> DeleteJobCategoryAsync(int id)
        {
            return jobCategoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobCategoryResponseModel>> GetAllJobCategoryAsync()
        {
            var result = await jobCategoryRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new JobCategoryResponseModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive
                });
            }
            return null;
        }

        public async Task<JobCategoryResponseModel> GetJobCategoryByIdAsync(int id)
        {
            var result = await jobCategoryRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new JobCategoryResponseModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateJobCategoryAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory()
            {
                Id = model.Id,
                Name = model.Name,
                IsActive = model.IsActive
            };
            return jobCategoryRepositoryAsync.UpdateAsync(jobCategory);
        }
    }
}
