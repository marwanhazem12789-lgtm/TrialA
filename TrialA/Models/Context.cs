using Microsoft.EntityFrameworkCore;

namespace TrialA.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> opt):base(opt) { } 
        public DbSet<Application> Applications { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<CandidateProfile> candidateProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                HasOne(i => i.Profile).
                WithOne(o => o.Candidate).
                HasForeignKey<CandidateProfile>(o => o.CandidateId).
                OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().
                HasMany(i => i.Companies).
                WithOne(o => o.Employer).
                HasForeignKey(o => o.EmployerId).
                OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Job>().
                HasOne(i => i.Company).
                WithMany(o => o.jobs).
                HasForeignKey(o => o.CompanyId).
                OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Job>().
                HasMany(i => i.Applications).
                WithOne(o => o.job).
                HasForeignKey(o => o.JobId).
                OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CandidateProfile>().
                HasMany(i => i.applications).
                WithOne(o => o.profile).
                HasForeignKey(o => o.ProfileId).
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>().
                HasIndex(o => o.Email).
                IsUnique();

            modelBuilder.Entity<Application>().
                HasIndex(o => new {o.JobId , o.ProfileId }).
                IsUnique();

           
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FullName = "Marwan Hazem",
                Email = "Maro@gmail.com",
                CreatedAt = new DateTime(2022, 5, 7),
                PassWord = "123",
                Role = "Admin"
               
            }, new User
            {
                Id = 2,
                FullName = "Anas Hazem",
                Email = "NN@gmail.com",
                CreatedAt = new DateTime(2018, 5, 7),
                PassWord = "456",
                Role = "Candidate"
            });

            modelBuilder.Entity<CandidateProfile>().HasData(new CandidateProfile
            {
                Id = 1,
                Phone = "01096857067",
                ResumeURL = "Ex.com/Res1",
                Skill = "Asp.net",
                YearsOfExperience = 3,CandidateId = 1
            },
            new CandidateProfile
            {
                Id = 2,
                Phone = "01121280689",
                ResumeURL = "Ex.com/Res2",
                Skill = "Java",
                YearsOfExperience = 2,CandidateId = 2
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 1,
                Description = "SoftWare",
                Website = "https://anything",
                Location = "Imbaba",
                EmployerId = 1,
                Name = "Teachmaze"

            }, new Company
            {
                Id = 2,
                Description = "IT",
                Website = "https://anything2",
                Location = "October",
                EmployerId = 2,
                Name = "Teachmaze2"

            });

            modelBuilder.Entity<Job>().HasData(new Job
            {
                Id = 1,
                Salary = 30000,
                Title = "Backend",
                Description = "Mottttt",
                Location = "imbaba",
                CompanyId = 1,
                Status = "Open",
                Deadline = new DateTime(2025, 5, 9),
                PostedDate = new DateTime(2022, 8, 5),
                EmploymentType = "FullTime"
            
            }, new Job
            {
                Id = 2,
                Salary = 50000,
                Title = "FrontEnd",
                Description = "Developer",
                Location = "imbaba",
                CompanyId = 2,
                Status = "Closed",
                Deadline = new DateTime(2027, 5, 9),
                PostedDate = new DateTime(2025, 8, 5),
                EmploymentType = "Contract"

            });
            modelBuilder.Entity<Application>().HasData(new Application
            {
                Id = 1,
                ProfileId = 1,
                JobId = 1,
                Status = "Pending",
                CoverLetter = "Intersted",
                ApplicationDate = new DateTime(2026, 8, 9)

            }, new Application
            {
                Id = 2,
                ProfileId =2,
                JobId = 2,
                Status = "Accepted",
                CoverLetter = "Very Intersted",
                ApplicationDate = new DateTime(2002, 8, 9)

            });
        }
    }
}
