namespace POISchedule.Data.Entities
{
using System.ComponentModel.DataAnnotations;
    public class Subject:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(35, ErrorMessage = "Debe introducir máximo {1} caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(7, ErrorMessage = "Debe introducir máximo {1} caracteres")]
        [Display(Name = "Clave")]
        public string Key { get; set; }

        
        [Display(Name = "Creditos")]
        public double Credits { get; set; }

    }
}
