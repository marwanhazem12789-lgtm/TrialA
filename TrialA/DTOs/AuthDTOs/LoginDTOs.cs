using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOs.AuthDTOs
{
    public class LoginDTOs
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required,]
        public string PassWord { get; set; }
    }
}
