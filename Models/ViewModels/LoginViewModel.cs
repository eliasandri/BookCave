using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
       public string Email { get; set; } 
        [Required(ErrorMessage="Email or password incorrect. Please try again.")]
       public string Password { get; set; }

       public bool RememberMe { get; set; }
    }
}