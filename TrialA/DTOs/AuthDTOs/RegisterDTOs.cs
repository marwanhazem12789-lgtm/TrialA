using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOs.AuthDTOs
{
    public class RegisterDTOs
    {
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required,]
        public string PassWord { get; set; }
        [Required, AllowedValues(("Admin"), ("Employer"), ("Candidate"))]
        public string Role { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
