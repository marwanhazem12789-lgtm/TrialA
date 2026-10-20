using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialA.Models
{
    public class CandidateProfile
    {
        [Key]
        public int Id { get; set; }
        [Required , Phone]
        public string Phone {  get; set; }
        public string? ResumeURL { get; set; }
        [Required , MaxLength(500)]
        public string Skill { get; set; }
        [Range(0 , 50)]
        public int YearsOfExperience { get; set; }
        public User Candidate { get; set; }
        [ForeignKey(nameof(User))]
        public int CandidateId { get; set; }


        public List<Application> applications { get; set; } = new List<Application>();
    }
}
