namespace TaskManagement.Models.Data
{
    public class Condition
    {
        public int Id { get; set; }
        public string CondName { get; set; }
        public ICollection<Service> Service { get; set; }


    }
}
