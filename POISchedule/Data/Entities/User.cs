namespace POISchedule.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    //TODO: 1 crear clase usuario
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50, ErrorMessage = "{0} the field must have a maximum of {1} characters")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50, ErrorMessage = "{0} the field must have a maximum of {1} characters")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Display(Name = "Número de ceular")]
        public override string PhoneNumber { get; set; }

        [Display(Name = "Full name")]
        public string FullName => $"{LastName} {FirstName}";
    }
}
