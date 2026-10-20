using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialA.Models
{
    [Index(nameof(Email) , IsUnique =true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required , MinLength(3) , MaxLength(100)]
        public string FullName { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required , ]
        public string PassWord { get; set; }
        [Required , AllowedValues(("Admin"),("Employer"),("Candidate"))]
        public string Role { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public CandidateProfile Profile { get; set; }
        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}
