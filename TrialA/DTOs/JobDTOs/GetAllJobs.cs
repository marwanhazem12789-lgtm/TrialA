using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOs.JobDTOs
{
    public class GetAllJobs
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required, Range(0, 1000000)]
        public decimal Salary { get; set; }
        [Required, AllowedValues(("FullTime"), ("PartTime"), ("Contract"), ("Internship"))]
        public string EmploymentType { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [Required, AllowedValues(("Open"), ("Close"))]
        public string Status { get; set; }

        public int CompanyId { get; set; }
        [Required, MaxLength(150)]
        public string CompanyName { get; set; }
        [Required, MaxLength(1000)]
        public string CompanyDescription { get; set; }
        public string? CompanyWebsite { get; set; }
        [Required]
        public string CompanyLocation { get; set; }


    }
}
