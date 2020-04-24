namespace POISchedule.Data
{
using Microsoft.EntityFrameworkCore;
using POISchedule.Data.Entities;

    public class DataContext:DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ClassroomType> ClassroomTypes { get; set; }
        public DbSet<CleaningStaff>  CleaningStaffs { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects{ get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
    }
}
