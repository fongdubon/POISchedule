namespace POISchedule.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RegisterNewUserViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50, ErrorMessage = "{0} the field must have a maximum of {1} characters")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50, ErrorMessage = "{0} the field must have a maximum of {1} characters")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Display(Name = "Número de celular")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Nombre de usuario")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} the field must have a maximum of {1} and minimum {2} characters")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password")]
        public string Confirm { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(1,int.MaxValue,ErrorMessage = "Must select a role")]
        [Display(Name = "Rol")]
        public int RolId { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
