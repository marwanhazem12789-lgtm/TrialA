using TrialA.AllCustoms.AuthCustom;
using TrialA.AllCustoms.CompanyCustom;
using TrialA.AllCustoms.JobCustom;
using TrialA.GenaricRepos;
using TrialA.Models;

namespace TrialA.UNITOFWORKS
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public IAuthRepo User {  get; }

        public ICompanyRepo Company { get; }

        public IJobRepo Job { get; }

        public IGenaricRepo<CandidateProfile> Profile { get; }

        public IGenaricRepo<Application> Application { get; }
        public UnitOfWork(Context c, IAuthRepo u, ICompanyRepo cp, IJobRepo j, IGenaricRepo<CandidateProfile> p, IGenaricRepo<Application> ap)
        {
            _context = c;
            User = u;
            Company = cp;
            Job = j;
            Profile = p;
            Application = ap;
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
