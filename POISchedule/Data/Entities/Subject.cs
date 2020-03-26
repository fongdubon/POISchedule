namespace POISchedule.Data.Entities
{
    public class Subject:IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Key { get; set; }
        public double Credits { get; set; }

    }
}
