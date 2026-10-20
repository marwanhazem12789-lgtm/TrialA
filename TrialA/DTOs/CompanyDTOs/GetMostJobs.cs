using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOs.CompanyDTOs
{
    public class GetMostJobs
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [Required, MaxLength(1000)]
        public string Description { get; set; }
        public string? Website { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
