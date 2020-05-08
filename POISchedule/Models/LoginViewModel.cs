namespace POISchedule.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "UserName")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} the field must have a maximum of {1} and minimum {2} characters")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        
        [Display(Name = "Rememeber Me?")] 
        public bool RememberMe { get; set; }
    }
}
