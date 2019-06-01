using System.ComponentModel.DataAnnotations;

namespace HomeBudget.Models.Account
{
    public class UserShortLoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
