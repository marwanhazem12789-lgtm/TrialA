using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOs.ApplicationDTOs
{
    public class GetAllApplication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required, AllowedValues(("Pending"), ("UnderReview"), ("Accepted"), ("Rejected"))]
        public string Status { get; set; }
        [MaxLength(2000)]
        public string? CoverLetter { get; set; }
    }
}
