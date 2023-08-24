namespace TaskManagement.Models.Data
{
    public class Personnel
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public ICollection<Service> Service { get; set; }
    }
}
