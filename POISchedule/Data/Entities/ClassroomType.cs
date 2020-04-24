
namespace POISchedule.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ClassroomType : IEntity
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "Debe introducir máximo {1} caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
