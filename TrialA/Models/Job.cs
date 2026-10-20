using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialA.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required , Range(0 , 1000000)]
        public decimal Salary { get; set; }
        [Required , AllowedValues(("FullTime"),("PartTime"),("Contract"),("Internship"))]
        public string EmploymentType { get; set; }
        [Required ]
        public DateTime PostedDate {  get; set; }
        [Required]
        public DateTime Deadline {  get; set; }
        [Required , AllowedValues(("Open"),("Close"))]
        public string Status { get; set; }

       public Company Company { get; set; }
        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }


        public ICollection<Application> Applications { get; set; } = new List<Application>();

    }
}
