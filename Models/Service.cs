using TaskManagement.Models;

namespace TaskManagement.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime RecordTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ServiceDescription { get; set; }
        public string WorkerNote { get; set; }
        public BTPersonnel BTPersonnel { get; set; }
        public Personnel Personnel { get; set; }
        public Condition Condition { get; set; }
   
    }
}