namespace POISchedule.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    //Chris
    public class Teacher : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Foto")]
        public string ImageUrl { get; set; }
    }
}
