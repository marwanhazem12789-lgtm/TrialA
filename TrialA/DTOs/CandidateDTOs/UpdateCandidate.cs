using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOs.CandidateDTOs
{
    public class UpdateCandidate
    {
        [Required, Phone]
        public string Phone { get; set; }
        public string? ResumeURL { get; set; }
        [Required, MaxLength(500)]
        public string Skill { get; set; }
        [Range(0, 50)]
        public int YearsOfExperience { get; set; }
        public int CandidateId { get; set; }


    }
}
