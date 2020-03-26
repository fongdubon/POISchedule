namespace POISchedule.Data.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
