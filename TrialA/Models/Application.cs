using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialA.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required , AllowedValues(("Pending"),("UnderReview"),("Accepted"),("Rejected"))]
        public string Status { get; set; }
        [MaxLength(2000)]
        public string? CoverLetter { get; set; }

        public Job job { get; set; }
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }


        public CandidateProfile profile { get; set; }
        [ForeignKey(nameof(CandidateProfile))]
        public int ProfileId { get; set; }
    }
}
