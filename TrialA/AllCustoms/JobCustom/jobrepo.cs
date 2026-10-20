using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrialA.DTOs.JobDTOs;
using TrialA.GenaricRepos;
using TrialA.Models;

namespace TrialA.AllCustoms.JobCustom
{
    public class jobrepo :GenaricRepo<Job> , IJobRepo
    {
       private readonly Context _context;
        public jobrepo(Context context):base(context)
        {
            _context = context;
        }

        public async Task<List<SearchJob>> Searcg(string Key)
        {
             var e = await _context.jobs.Where(p => p.Title.Contains(Key) || p.Description.Contains(Key)).Select(t => new SearchJob
            {
                Title = t.Title,
                Salary = t.Salary,
                Status = t.Status,
                Deadline = t.Deadline,
                Description = t.Description,
                EmploymentType = t.EmploymentType,
                Id = t.Id,
                Location = t.Location,
                PostedDate = t.PostedDate,
            }).ToListAsync();
            if(e.Count< 0)
            {
                throw new Exception("Not Found");
            }
            return e;
        }

        public async Task<List<DTOs.JobDTOs.GetAllJobs>> GetById2(int id)
        {
            return await _context.jobs.Include(o => o.Company).Where(p => p.Id== id).Select(t => new GetAllJobs
            {
                Title = t.Title,
                Salary = t.Salary,
                Status = t.Status,
                Deadline = t.Deadline,
                Description = t.Description,
                EmploymentType = t.EmploymentType,
                Id = t.Id,
                Location = t.Location,
                PostedDate = t.PostedDate,
                CompanyDescription = t.Company.Description,
                CompanyId = t.CompanyId,
                CompanyLocation = t.Company.Location,
                CompanyName = t.Company.Name,
                CompanyWebsite = t.Company.Website,
            }).ToListAsync();

        }

        public async Task<decimal> Hishest()
        {
            var t =  await _context.jobs.OrderByDescending(o => o.Salary).Select(o => o.Salary).Distinct().Skip(2).FirstOrDefaultAsync();
            return t;
        }
    }
}
