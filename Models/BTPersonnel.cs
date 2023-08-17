using TaskManagement.Models;

namespace TaskManagement.Models
{
    public class BTPersonnel
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set;}
        public string MobilPhoneNumber { get; set;}
        public string Mail { get; set; }
        public string Authority { get; set; }
        public ICollection<Service> Service { get; set; }

    }
}
