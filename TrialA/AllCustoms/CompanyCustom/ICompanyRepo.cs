using TrialA.DTOs.CompanyDTOs;
using TrialA.DTOs.JobDTOs;
using TrialA.GenaricRepos;
using TrialA.Models;

namespace TrialA.AllCustoms.CompanyCustom
{
    public interface ICompanyRepo : IGenaricRepo<Company>
    {
        Task<List<GetMostJobs>> GetTob();
    }
}
