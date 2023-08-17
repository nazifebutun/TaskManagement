namespace TaskManagement.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepName { get; set; }
        public ICollection<Personnel> Personnel { get; set; }
    }
}
