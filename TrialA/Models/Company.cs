using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialA.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(150)]
        public string Name { get; set; }
        [Required , MaxLength(1000)]
        public string Description { get; set; }
        public string? Website { get; set; }
        [Required]
        public string Location { get; set; }


        public User Employer { get; set; }
        [ForeignKey(nameof(User))]
        public int EmployerId { get; set; }


        public ICollection<Job> jobs { get; set; } = new List<Job>();
    }
}
