using TrialA.GenaricRepos;
using TrialA.Models;

namespace TrialA.AllCustoms.JobCustom
{
    public interface IJobRepo : IGenaricRepo<Job>
    {
        Task<List<DTOs.JobDTOs.GetAllJobs>> GetById2(int id);
        Task<List<DTOs.JobDTOs.SearchJob>> Searcg(string Key);
        Task<decimal> Hishest();
    }
}
