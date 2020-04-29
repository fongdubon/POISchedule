namespace POISchedule.Models
{
    using Microsoft.AspNetCore.Http;
    using POISchedule.Data.Entities;
    using System.ComponentModel.DataAnnotations;

    public class CoordinatorViewModel : Coordinator
    {
        [Display(Name = "Foto")]
        public IFormFile ImageFile { get; set; }
    }
}
