using Hrm.ApplicationCore.Model.Request;
using Hrm.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.ApplicationCore.Contract.Service
{
    public interface ICandidateServiceAsync
    {
        Task<int> AddCandidateAsync(CandidateRequestModel model);
        Task<int> UpdateCandidateAsync(CandidateRequestModel model);
        Task<int> DeleteCandidateAsync(int id);
        Task<CandidateResponseModel> GetCandidateByIdAsync(int id);
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidatesAsync();
    }
}
