
namespace POISchedule.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    //Gus
    public class Student : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "Debe introducir máximo {1} caracteres")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "Debe introducir máximo {1} caracteres")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Display(Name = "Foto")]
        public string ImageUrl { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
