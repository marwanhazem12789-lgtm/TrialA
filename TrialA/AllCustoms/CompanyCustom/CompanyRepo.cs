using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using TrialA.DTOs.CompanyDTOs;
using TrialA.GenaricRepos;
using TrialA.Models;

namespace TrialA.AllCustoms.CompanyCustom
{
    public class CompanyRepo : GenaricRepo<Company> , ICompanyRepo
    {
        private readonly Context _context;
        public CompanyRepo(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<GetMostJobs>> GetTob()
        {
            return await _context.companies.Include(o => o.jobs)
                .OrderByDescending(i => i.jobs.Count())
                .ThenBy(l => l.Location)
                .Select(i => new GetMostJobs
            {
                Description = i.Description,
                Id = i.Id,
                Location = i.Location,
                Name = i.Name,
                Website = i.Website,

            }).ToListAsync();
        }
    }
}
