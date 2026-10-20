using TrialA.AllCustoms.AuthCustom;
using TrialA.AllCustoms.CompanyCustom;
using TrialA.AllCustoms.JobCustom;
using TrialA.GenaricRepos;
using TrialA.Models;

namespace TrialA.UNITOFWORKS
{
    public interface IUnitOfWork
    {
        public IAuthRepo User { get; }
        public ICompanyRepo Company { get; }
        public IJobRepo Job { get; }
        public IGenaricRepo<CandidateProfile> Profile { get; }
        public IGenaricRepo<Application> Application { get; }

        public Task<int> Save();
    }
}
